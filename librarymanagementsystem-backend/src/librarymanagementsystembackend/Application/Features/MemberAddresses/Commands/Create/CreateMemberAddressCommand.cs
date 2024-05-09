using Application.Features.MemberAddresses.Constants;
using Application.Features.MemberAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MemberAddresses.Constants.MemberAddressesOperationClaims;

namespace Application.Features.MemberAddresses.Commands.Create;

public class CreateMemberAddressCommand : IRequest<CreatedMemberAddressResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }

    public string[] Roles => [Admin, Write, MemberAddressesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberAddresses"];

    public class CreateMemberAddressCommandHandler : IRequestHandler<CreateMemberAddressCommand, CreatedMemberAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAddressRepository _memberAddressRepository;
        private readonly MemberAddressBusinessRules _memberAddressBusinessRules;

        public CreateMemberAddressCommandHandler(IMapper mapper, IMemberAddressRepository memberAddressRepository,
                                         MemberAddressBusinessRules memberAddressBusinessRules)
        {
            _mapper = mapper;
            _memberAddressRepository = memberAddressRepository;
            _memberAddressBusinessRules = memberAddressBusinessRules;
        }

        public async Task<CreatedMemberAddressResponse> Handle(CreateMemberAddressCommand request, CancellationToken cancellationToken)
        {
            MemberAddress memberAddress = _mapper.Map<MemberAddress>(request);

            await _memberAddressRepository.AddAsync(memberAddress);

            CreatedMemberAddressResponse response = _mapper.Map<CreatedMemberAddressResponse>(memberAddress);
            return response;
        }
    }
}