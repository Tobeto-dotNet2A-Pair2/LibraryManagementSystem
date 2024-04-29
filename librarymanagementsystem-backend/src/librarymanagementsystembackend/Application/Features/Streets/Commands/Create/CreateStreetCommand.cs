using Application.Features.Streets.Constants;
using Application.Features.Streets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Streets.Constants.StreetsOperationClaims;

namespace Application.Features.Streets.Commands.Create;

public class CreateStreetCommand : IRequest<CreatedStreetResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest, 
{
    public string Name { get; set; }
    public Guid NeighborhoodId { get; set; }

    public string[] Roles => [Admin, Write, StreetsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStreets"];

    public class CreateStreetCommandHandler : IRequestHandler<CreateStreetCommand, CreatedStreetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;
        private readonly StreetBusinessRules _streetBusinessRules;

        public CreateStreetCommandHandler(IMapper mapper, IStreetRepository streetRepository,
                                         StreetBusinessRules streetBusinessRules)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
            _streetBusinessRules = streetBusinessRules;
        }

        public async Task<CreatedStreetResponse> Handle(CreateStreetCommand request, CancellationToken cancellationToken)
        {
            Street street = _mapper.Map<Street>(request);

            await _streetRepository.AddAsync(street);

            CreatedStreetResponse response = _mapper.Map<CreatedStreetResponse>(street);
            return response;
        }
    }
}