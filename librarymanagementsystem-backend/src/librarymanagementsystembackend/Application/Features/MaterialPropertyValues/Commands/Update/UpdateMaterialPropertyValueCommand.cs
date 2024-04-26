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

namespace Application.Features.MaterialPropertyValues.Commands.Update;

public class UpdateMaterialPropertyValueCommand : IRequest<UpdatedMaterialPropertyValueResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }

    public string[] Roles => [Admin, Write, MaterialPropertyValuesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialPropertyValues"];

    public class UpdateMaterialPropertyValueCommandHandler : IRequestHandler<UpdateMaterialPropertyValueCommand, UpdatedMaterialPropertyValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
        private readonly MaterialPropertyValueBusinessRules _materialPropertyValueBusinessRules;

        public UpdateMaterialPropertyValueCommandHandler(IMapper mapper, IMaterialPropertyValueRepository materialPropertyValueRepository,
                                         MaterialPropertyValueBusinessRules materialPropertyValueBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyValueRepository = materialPropertyValueRepository;
            _materialPropertyValueBusinessRules = materialPropertyValueBusinessRules;
        }

        public async Task<UpdatedMaterialPropertyValueResponse> Handle(UpdateMaterialPropertyValueCommand request, CancellationToken cancellationToken)
        {
            MaterialPropertyValue? materialPropertyValue = await _materialPropertyValueRepository.GetAsync(predicate: mpv => mpv.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPropertyValueBusinessRules.MaterialPropertyValueShouldExistWhenSelected(materialPropertyValue);
            materialPropertyValue = _mapper.Map(request, materialPropertyValue);

            await _materialPropertyValueRepository.UpdateAsync(materialPropertyValue!);

            UpdatedMaterialPropertyValueResponse response = _mapper.Map<UpdatedMaterialPropertyValueResponse>(materialPropertyValue);
            return response;
        }
    }
}