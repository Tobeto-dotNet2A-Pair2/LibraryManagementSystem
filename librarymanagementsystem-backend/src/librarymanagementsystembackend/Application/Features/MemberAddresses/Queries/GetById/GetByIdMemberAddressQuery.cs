using Application.Features.MemberAddresses.Constants;
using Application.Features.MemberAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MemberAddresses.Constants.MemberAddressesOperationClaims;

namespace Application.Features.MemberAddresses.Queries.GetById;

public class GetByIdMemberAddressQuery : IRequest<GetByIdMemberAddressResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMemberAddressQueryHandler : IRequestHandler<GetByIdMemberAddressQuery, GetByIdMemberAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAddressRepository _memberAddressRepository;
        private readonly MemberAddressBusinessRules _memberAddressBusinessRules;

        public GetByIdMemberAddressQueryHandler(IMapper mapper, IMemberAddressRepository memberAddressRepository, MemberAddressBusinessRules memberAddressBusinessRules)
        {
            _mapper = mapper;
            _memberAddressRepository = memberAddressRepository;
            _memberAddressBusinessRules = memberAddressBusinessRules;
        }

        public async Task<GetByIdMemberAddressResponse> Handle(GetByIdMemberAddressQuery request, CancellationToken cancellationToken)
        {
            MemberAddress? memberAddress = await _memberAddressRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _memberAddressBusinessRules.MemberAddressShouldExistWhenSelected(memberAddress);

            GetByIdMemberAddressResponse response = _mapper.Map<GetByIdMemberAddressResponse>(memberAddress);
            return response;
        }
    }
}