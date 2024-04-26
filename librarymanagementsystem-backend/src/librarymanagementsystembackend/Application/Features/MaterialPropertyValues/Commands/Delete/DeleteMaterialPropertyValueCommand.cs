using Application.Features.MaterialPropertyValues.Constants;
using Application.Features.MaterialPropertyValues.Constants;
using Application.Features.MaterialPropertyValues.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialPropertyValues.Constants.MaterialPropertyValuesOperationClaims;

namespace Application.Features.MaterialPropertyValues.Commands.Delete;

public class DeleteMaterialPropertyValueCommand : IRequest<DeletedMaterialPropertyValueResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialPropertyValuesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialPropertyValues"];

    public class DeleteMaterialPropertyValueCommandHandler : IRequestHandler<DeleteMaterialPropertyValueCommand, DeletedMaterialPropertyValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
        private readonly MaterialPropertyValueBusinessRules _materialPropertyValueBusinessRules;

        public DeleteMaterialPropertyValueCommandHandler(IMapper mapper, IMaterialPropertyValueRepository materialPropertyValueRepository,
                                         MaterialPropertyValueBusinessRules materialPropertyValueBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyValueRepository = materialPropertyValueRepository;
            _materialPropertyValueBusinessRules = materialPropertyValueBusinessRules;
        }

        public async Task<DeletedMaterialPropertyValueResponse> Handle(DeleteMaterialPropertyValueCommand request, CancellationToken cancellationToken)
        {
            MaterialPropertyValue? materialPropertyValue = await _materialPropertyValueRepository.GetAsync(predicate: mpv => mpv.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPropertyValueBusinessRules.MaterialPropertyValueShouldExistWhenSelected(materialPropertyValue);

            await _materialPropertyValueRepository.DeleteAsync(materialPropertyValue!);

            DeletedMaterialPropertyValueResponse response = _mapper.Map<DeletedMaterialPropertyValueResponse>(materialPropertyValue);
            return response;
        }
    }
}