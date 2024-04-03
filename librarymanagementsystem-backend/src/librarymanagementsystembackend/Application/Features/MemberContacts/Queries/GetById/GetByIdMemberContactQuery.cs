using Application.Features.MemberContacts.Constants;
using Application.Features.MemberContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MemberContacts.Constants.MemberContactsOperationClaims;

namespace Application.Features.MemberContacts.Queries.GetById;

public class GetByIdMemberContactQuery : IRequest<GetByIdMemberContactResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMemberContactQueryHandler : IRequestHandler<GetByIdMemberContactQuery, GetByIdMemberContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContactRepository _memberContactRepository;
        private readonly MemberContactBusinessRules _memberContactBusinessRules;

        public GetByIdMemberContactQueryHandler(IMapper mapper, IMemberContactRepository memberContactRepository, MemberContactBusinessRules memberContactBusinessRules)
        {
            _mapper = mapper;
            _memberContactRepository = memberContactRepository;
            _memberContactBusinessRules = memberContactBusinessRules;
        }

        public async Task<GetByIdMemberContactResponse> Handle(GetByIdMemberContactQuery request, CancellationToken cancellationToken)
        {
            MemberContact? memberContact = await _memberContactRepository.GetAsync(predicate: mc => mc.Id == request.Id, cancellationToken: cancellationToken);
            await _memberContactBusinessRules.MemberContactShouldExistWhenSelected(memberContact);

            GetByIdMemberContactResponse response = _mapper.Map<GetByIdMemberContactResponse>(memberContact);
            return response;
        }
    }
}