using Application.Features.Addresses.Constants;
using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Addresses.Constants.AddressesOperationClaims;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommand : IRequest<UpdatedAddressResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid StreetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, AddressesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAddresses"];

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public UpdateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<UpdatedAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);
            address = _mapper.Map(request, address);

            await _addressRepository.UpdateAsync(address!);

            UpdatedAddressResponse response = _mapper.Map<UpdatedAddressResponse>(address);
            return response;
        }
    }
}