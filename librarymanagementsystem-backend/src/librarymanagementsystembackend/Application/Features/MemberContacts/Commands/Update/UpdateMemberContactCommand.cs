using Application.Features.MemberContacts.Constants;
using Application.Features.MemberContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MemberContacts.Constants.MemberContactsOperationClaims;

namespace Application.Features.MemberContacts.Commands.Update;

public class UpdateMemberContactCommand : IRequest<UpdatedMemberContactResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public string Message { get; set; }
    public Guid MemberId { get; set; }
    public Guid LibraryId { get; set; }

    public string[] Roles => [Admin, Write, MemberContactsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberContacts"];

    public class UpdateMemberContactCommandHandler : IRequestHandler<UpdateMemberContactCommand, UpdatedMemberContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContactRepository _memberContactRepository;
        private readonly MemberContactBusinessRules _memberContactBusinessRules;

        public UpdateMemberContactCommandHandler(IMapper mapper, IMemberContactRepository memberContactRepository,
                                         MemberContactBusinessRules memberContactBusinessRules)
        {
            _mapper = mapper;
            _memberContactRepository = memberContactRepository;
            _memberContactBusinessRules = memberContactBusinessRules;
        }

        public async Task<UpdatedMemberContactResponse> Handle(UpdateMemberContactCommand request, CancellationToken cancellationToken)
        {
            MemberContact? memberContact = await _memberContactRepository.GetAsync(predicate: mc => mc.Id == request.Id, cancellationToken: cancellationToken);
            await _memberContactBusinessRules.MemberContactShouldExistWhenSelected(memberContact);
            memberContact = _mapper.Map(request, memberContact);

            await _memberContactRepository.UpdateAsync(memberContact!);

            UpdatedMemberContactResponse response = _mapper.Map<UpdatedMemberContactResponse>(memberContact);
            return response;
        }
    }
}