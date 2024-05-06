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

namespace Application.Features.MaterialPropertyValues.Commands.Create;

public class CreateMaterialPropertyValueCommand : IRequest<CreatedMaterialPropertyValueResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public string Content { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }

    public string[] Roles => [Admin, Write, MaterialPropertyValuesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialPropertyValues"];

    public class CreateMaterialPropertyValueCommandHandler : IRequestHandler<CreateMaterialPropertyValueCommand, CreatedMaterialPropertyValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
        private readonly MaterialPropertyValueBusinessRules _materialPropertyValueBusinessRules;

        public CreateMaterialPropertyValueCommandHandler(IMapper mapper, IMaterialPropertyValueRepository materialPropertyValueRepository,
                                         MaterialPropertyValueBusinessRules materialPropertyValueBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyValueRepository = materialPropertyValueRepository;
            _materialPropertyValueBusinessRules = materialPropertyValueBusinessRules;
        }

        public async Task<CreatedMaterialPropertyValueResponse> Handle(CreateMaterialPropertyValueCommand request, CancellationToken cancellationToken)
        {
            MaterialPropertyValue materialPropertyValue = _mapper.Map<MaterialPropertyValue>(request);

            await _materialPropertyValueRepository.AddAsync(materialPropertyValue);

            CreatedMaterialPropertyValueResponse response = _mapper.Map<CreatedMaterialPropertyValueResponse>(materialPropertyValue);
            return response;
        }
    }
}