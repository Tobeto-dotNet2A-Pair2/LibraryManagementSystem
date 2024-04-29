using Application.Features.Addresses.Constants;
using Application.Features.Addresses.Dtos;
using Application.Features.Addresses.Rules;
using Application.Features.MaterialProperties.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Addresses.Constants.AddressesOperationClaims;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommand : IRequest<CreatedAddressResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public CreateAddressCommand()
    {
        District = new CreateAddressDistrictDto();
    }
    public Guid StreetId { get; set; }
    public CreateAddressDistrictDto District { get; set; }
    
    public CreateAddressDistrictDto District2 { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, AddressesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAddresses"];

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CreatedAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);

            await _addressRepository.AddAsync(address);

            CreatedAddressResponse response = _mapper.Map<CreatedAddressResponse>(address);
            return response;
        }
    }
}