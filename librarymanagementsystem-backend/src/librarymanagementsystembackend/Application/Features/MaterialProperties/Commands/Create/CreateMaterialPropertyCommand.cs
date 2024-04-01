using Application.Features.MaterialProperties.Constants;
using Application.Features.MaterialProperties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialProperties.Constants.MaterialPropertiesOperationClaims;

namespace Application.Features.MaterialProperties.Commands.Create;

public class CreateMaterialPropertyCommand : IRequest<CreatedMaterialPropertyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string MaterialPropertyName { get; set; }

    public string[] Roles => [Admin, Write, MaterialPropertiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialProperties"];

    public class CreateMaterialPropertyCommandHandler : IRequestHandler<CreateMaterialPropertyCommand, CreatedMaterialPropertyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly MaterialPropertyBusinessRules _materialPropertyBusinessRules;

        public CreateMaterialPropertyCommandHandler(IMapper mapper, IMaterialPropertyRepository materialPropertyRepository,
                                         MaterialPropertyBusinessRules materialPropertyBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyRepository = materialPropertyRepository;
            _materialPropertyBusinessRules = materialPropertyBusinessRules;
        }

        public async Task<CreatedMaterialPropertyResponse> Handle(CreateMaterialPropertyCommand request, CancellationToken cancellationToken)
        {
            MaterialProperty materialProperty = _mapper.Map<MaterialProperty>(request);

            await _materialPropertyRepository.AddAsync(materialProperty);

            CreatedMaterialPropertyResponse response = _mapper.Map<CreatedMaterialPropertyResponse>(materialProperty);
            return response;
        }
    }
}