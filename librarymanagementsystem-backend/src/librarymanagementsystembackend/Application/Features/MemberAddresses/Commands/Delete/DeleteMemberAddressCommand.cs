using Application.Features.MemberAddresses.Constants;
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

namespace Application.Features.MemberAddresses.Commands.Delete;

public class DeleteMemberAddressCommand : IRequest<DeletedMemberAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MemberAddressesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMemberAddresses"];

    public class DeleteMemberAddressCommandHandler : IRequestHandler<DeleteMemberAddressCommand, DeletedMemberAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAddressRepository _memberAddressRepository;
        private readonly MemberAddressBusinessRules _memberAddressBusinessRules;

        public DeleteMemberAddressCommandHandler(IMapper mapper, IMemberAddressRepository memberAddressRepository,
                                         MemberAddressBusinessRules memberAddressBusinessRules)
        {
            _mapper = mapper;
            _memberAddressRepository = memberAddressRepository;
            _memberAddressBusinessRules = memberAddressBusinessRules;
        }

        public async Task<DeletedMemberAddressResponse> Handle(DeleteMemberAddressCommand request, CancellationToken cancellationToken)
        {
            MemberAddress? memberAddress = await _memberAddressRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _memberAddressBusinessRules.MemberAddressShouldExistWhenSelected(memberAddress);

            await _memberAddressRepository.DeleteAsync(memberAddress!);

            DeletedMemberAddressResponse response = _mapper.Map<DeletedMemberAddressResponse>(memberAddress);
            return response;
        }
    }
}