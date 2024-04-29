using Application.Features.MemberContacts.Constants;
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

namespace Application.Features.MemberContacts.Commands.Delete;

public class DeleteMemberContactCommand : IRequest<DeletedMemberContactResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MemberContactsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberContacts"];

    public class DeleteMemberContactCommandHandler : IRequestHandler<DeleteMemberContactCommand, DeletedMemberContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContactRepository _memberContactRepository;
        private readonly MemberContactBusinessRules _memberContactBusinessRules;

        public DeleteMemberContactCommandHandler(IMapper mapper, IMemberContactRepository memberContactRepository,
                                         MemberContactBusinessRules memberContactBusinessRules)
        {
            _mapper = mapper;
            _memberContactRepository = memberContactRepository;
            _memberContactBusinessRules = memberContactBusinessRules;
        }

        public async Task<DeletedMemberContactResponse> Handle(DeleteMemberContactCommand request, CancellationToken cancellationToken)
        {
            MemberContact? memberContact = await _memberContactRepository.GetAsync(predicate: mc => mc.Id == request.Id, cancellationToken: cancellationToken);
            await _memberContactBusinessRules.MemberContactShouldExistWhenSelected(memberContact);

            await _memberContactRepository.DeleteAsync(memberContact!);

            DeletedMemberContactResponse response = _mapper.Map<DeletedMemberContactResponse>(memberContact);
            return response;
        }
    }
}