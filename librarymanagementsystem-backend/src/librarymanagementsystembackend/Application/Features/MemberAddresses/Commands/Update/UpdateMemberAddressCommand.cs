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

namespace Application.Features.MemberAddresses.Commands.Update;

public class UpdateMemberAddressCommand : IRequest<UpdatedMemberAddressResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AddressId { get; set; }

    public string[] Roles => [Admin, Write, MemberAddressesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberAddresses"];

    public class UpdateMemberAddressCommandHandler : IRequestHandler<UpdateMemberAddressCommand, UpdatedMemberAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAddressRepository _memberAddressRepository;
        private readonly MemberAddressBusinessRules _memberAddressBusinessRules;

        public UpdateMemberAddressCommandHandler(IMapper mapper, IMemberAddressRepository memberAddressRepository,
                                         MemberAddressBusinessRules memberAddressBusinessRules)
        {
            _mapper = mapper;
            _memberAddressRepository = memberAddressRepository;
            _memberAddressBusinessRules = memberAddressBusinessRules;
        }

        public async Task<UpdatedMemberAddressResponse> Handle(UpdateMemberAddressCommand request, CancellationToken cancellationToken)
        {
            MemberAddress? memberAddress = await _memberAddressRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _memberAddressBusinessRules.MemberAddressShouldExistWhenSelected(memberAddress);
            memberAddress = _mapper.Map(request, memberAddress);

            await _memberAddressRepository.UpdateAsync(memberAddress!);

            UpdatedMemberAddressResponse response = _mapper.Map<UpdatedMemberAddressResponse>(memberAddress);
            return response;
        }
    }
}