using Application.Features.MaterialProperties.Constants;
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

namespace Application.Features.MaterialProperties.Commands.Delete;

public class DeleteMaterialPropertyCommand : IRequest<DeletedMaterialPropertyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialPropertiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialProperties"];

    public class DeleteMaterialPropertyCommandHandler : IRequestHandler<DeleteMaterialPropertyCommand, DeletedMaterialPropertyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly MaterialPropertyBusinessRules _materialPropertyBusinessRules;

        public DeleteMaterialPropertyCommandHandler(IMapper mapper, IMaterialPropertyRepository materialPropertyRepository,
                                         MaterialPropertyBusinessRules materialPropertyBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyRepository = materialPropertyRepository;
            _materialPropertyBusinessRules = materialPropertyBusinessRules;
        }

        public async Task<DeletedMaterialPropertyResponse> Handle(DeleteMaterialPropertyCommand request, CancellationToken cancellationToken)
        {
            MaterialProperty? materialProperty = await _materialPropertyRepository.GetAsync(predicate: mp => mp.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPropertyBusinessRules.MaterialPropertyShouldExistWhenSelected(materialProperty);

            await _materialPropertyRepository.DeleteAsync(materialProperty!);

            DeletedMaterialPropertyResponse response = _mapper.Map<DeletedMaterialPropertyResponse>(materialProperty);
            return response;
        }
    }
}