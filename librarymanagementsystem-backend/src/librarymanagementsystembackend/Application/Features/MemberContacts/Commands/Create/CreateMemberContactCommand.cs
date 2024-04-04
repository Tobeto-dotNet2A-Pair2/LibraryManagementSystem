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

namespace Application.Features.MemberContacts.Commands.Create;

public class CreateMemberContactCommand : IRequest<CreatedMemberContactResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public string Messages { get; set; }
    public Guid MemberId { get; set; }

    public string[] Roles => [Admin, Write, MemberContactsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberContacts"];

    public class CreateMemberContactCommandHandler : IRequestHandler<CreateMemberContactCommand, CreatedMemberContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContactRepository _memberContactRepository;
        private readonly MemberContactBusinessRules _memberContactBusinessRules;

        public CreateMemberContactCommandHandler(IMapper mapper, IMemberContactRepository memberContactRepository,
                                         MemberContactBusinessRules memberContactBusinessRules)
        {
            _mapper = mapper;
            _memberContactRepository = memberContactRepository;
            _memberContactBusinessRules = memberContactBusinessRules;
        }

        public async Task<CreatedMemberContactResponse> Handle(CreateMemberContactCommand request, CancellationToken cancellationToken)
        {
            MemberContact memberContact = _mapper.Map<MemberContact>(request);

            await _memberContactRepository.AddAsync(memberContact);

            CreatedMemberContactResponse response = _mapper.Map<CreatedMemberContactResponse>(memberContact);
            return response;
        }
    }
}