using Application.Features.Members.Constants;
using Application.Features.Members.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Members.Constants.MembersOperationClaims;

namespace Application.Features.Members.Commands.Update;

public class UpdateMemberCommand : IRequest<UpdatedMemberResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TC { get; set; }
    public string PhoneNumber { get; set; }
    public string Photo { get; set; }
    public string? Position { get; set; }
    public decimal TotalDebt { get; set; }
    public Guid UserId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => [Admin, Write, MembersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMembers"];

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, UpdatedMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly MemberBusinessRules _memberBusinessRules;

        public UpdateMemberCommandHandler(IMapper mapper, IMemberRepository memberRepository,
                                         MemberBusinessRules memberBusinessRules)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
            _memberBusinessRules = memberBusinessRules;
        }

        public async Task<UpdatedMemberResponse> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            Member? member = await _memberRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _memberBusinessRules.MemberShouldExistWhenSelected(member);
            member = _mapper.Map(request, member);

            await _memberRepository.UpdateAsync(member!);

            UpdatedMemberResponse response = _mapper.Map<UpdatedMemberResponse>(member);
            return response;
        }
    }
}