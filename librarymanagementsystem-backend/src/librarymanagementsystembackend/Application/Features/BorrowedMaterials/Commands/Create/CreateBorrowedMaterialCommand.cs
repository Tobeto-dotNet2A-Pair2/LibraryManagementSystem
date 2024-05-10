using Application.Features.BorrowedMaterials.Constants;
using Application.Features.BorrowedMaterials.Dtos;
using Application.Features.BorrowedMaterials.Rules;
using Application.Features.MaterialCopies.Rules;
using Application.Features.Members.Dtos;
using Application.Features.Members.Rules;
using Application.Services.MaterialCopies;
using Application.Services.Members;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using MimeKit;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Mailing;
using System.Globalization;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommand : IRequest<CreatedBorrowedMaterialResponse>, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid UserId { get; set; }
    public Guid MaterialCopyId { get; set; }

    public string[] Roles => [BorrowedMaterialsOperationClaims.Admin, BorrowedMaterialsOperationClaims.Write, BorrowedMaterialsOperationClaims.Create];
    public class CreateBorrowedMaterialCommandHandler : IRequestHandler<CreateBorrowedMaterialCommand, CreatedBorrowedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;
        private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;
        private readonly MemberBusinessRules _memberBusinessRules;
        private readonly IMaterialCopyService _materialCopyService;
        private readonly IMailService _mailService;
        private readonly IMemberService _memberService;

        public CreateBorrowedMaterialCommandHandler(IMapper mapper, 
            IBorrowedMaterialRepository borrowedMaterialRepository,
            BorrowedMaterialBusinessRules borrowedMaterialBusinessRules, 
            MaterialCopyBusinessRules materialCopyBusinessRules, 
            IMaterialCopyService materialCopyService, 
            MemberBusinessRules memberBusinessRules, 
            IMailService mailService, 
            IMemberService memberService)
        {
            _mapper = mapper;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
            _materialCopyBusinessRules = materialCopyBusinessRules;
            _materialCopyService = materialCopyService;
            _memberBusinessRules = memberBusinessRules;
            _mailService = mailService;
            _memberService = memberService;
        }

        public async Task<CreatedBorrowedMaterialResponse> Handle(CreateBorrowedMaterialCommand request, CancellationToken cancellationToken)
        {
            Guid memberId = await _memberService.GetMemberIdByUserId(request.UserId);
            #region BusinessRules
            
            await _borrowedMaterialBusinessRules.MemberDoesNotHaveSameMaterialAtTheSameTime(memberId, request.MaterialCopyId, cancellationToken);
            await _memberBusinessRules.MemberShouldHaveNoDebt(memberId, cancellationToken);
            await _materialCopyBusinessRules.MaterialCopyIsShouldReservableWhenBorrowed(request.MaterialCopyId,cancellationToken);

            #endregion
         
            #region Checks And Insert
            GetForBorrowDto materialWithCopy = await _materialCopyService.GetForBorrow(request.MaterialCopyId);
            if (materialWithCopy is null) //TODO : Message have to replace with localization service.
                throw new Exception("The requested material can not be found");


            var borrowedMaterial = new BorrowedMaterial()
            {
                MaterialCopyId = request.MaterialCopyId,
                MemberId = memberId
            };

            borrowedMaterial.ReturnDate = DateTime.UtcNow.AddDays(materialWithCopy.BorrowDay);
            await _borrowedMaterialRepository.AddAsync(borrowedMaterial);
            
            #endregion

            await _materialCopyService.UpdateAfterBorrow(request.MaterialCopyId);

            #region Mail 

            GetMemberForEmailDto member = await _memberService.GetForEmailById(memberId, cancellationToken: cancellationToken);
            var mail = new Mail(
                subject: BorrowedMaterialsBusinessMessages.BorrowedMaterialEmailSubject,
                textBody: string.Empty,
                htmlBody: BorrowedMaterialsBusinessMessages.BorrowedMaterialEmailHtmlBody
                            .Replace("%FullName%", string.Concat(member.FirstName, member.LastName))
                            .Replace("%MaterialName%", materialWithCopy.Name)
                            .Replace("%ReturnDate%", borrowedMaterial.ReturnDate.ToString(CultureInfo.InvariantCulture)),
                [new MailboxAddress(string.Concat(member.FirstName, member.LastName), member.Email)]);

            await _mailService.SendEmailAsync(mail);

            #endregion

            #region Response

            var response = _mapper.Map<CreatedBorrowedMaterialResponse>(borrowedMaterial);
            response.PunishmentAmount = materialWithCopy.PunishmentAmount;

            return response;
            #endregion
        }
    }
}