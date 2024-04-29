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

namespace Application.Features.MaterialProperties.Commands.Update;

public class UpdateMaterialPropertyCommand : IRequest<UpdatedMaterialPropertyResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, MaterialPropertiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialProperties"];

    public class UpdateMaterialPropertyCommandHandler : IRequestHandler<UpdateMaterialPropertyCommand, UpdatedMaterialPropertyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly MaterialPropertyBusinessRules _materialPropertyBusinessRules;

        public UpdateMaterialPropertyCommandHandler(IMapper mapper, IMaterialPropertyRepository materialPropertyRepository,
                                         MaterialPropertyBusinessRules materialPropertyBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyRepository = materialPropertyRepository;
            _materialPropertyBusinessRules = materialPropertyBusinessRules;
        }

        public async Task<UpdatedMaterialPropertyResponse> Handle(UpdateMaterialPropertyCommand request, CancellationToken cancellationToken)
        {
            MaterialProperty? materialProperty = await _materialPropertyRepository.GetAsync(predicate: mp => mp.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPropertyBusinessRules.MaterialPropertyShouldExistWhenSelected(materialProperty);
            materialProperty = _mapper.Map(request, materialProperty);

            await _materialPropertyRepository.UpdateAsync(materialProperty!);

            UpdatedMaterialPropertyResponse response = _mapper.Map<UpdatedMaterialPropertyResponse>(materialProperty);
            return response;
        }
    }
}