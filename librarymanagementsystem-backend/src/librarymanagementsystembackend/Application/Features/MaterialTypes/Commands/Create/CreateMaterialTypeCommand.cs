using Application.Features.MaterialTypes.Constants;
using Application.Features.MaterialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialTypes.Constants.MaterialTypesOperationClaims;
using Domain.Enums;

namespace Application.Features.MaterialTypes.Commands.Create;

public class CreateMaterialTypeCommand : IRequest<CreatedMaterialTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }

    public string[] Roles => [Admin, Write, MaterialTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialTypes"];

    public class CreateMaterialTypeCommandHandler : IRequestHandler<CreateMaterialTypeCommand, CreatedMaterialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly MaterialTypeBusinessRules _materialTypeBusinessRules;

        public CreateMaterialTypeCommandHandler(IMapper mapper, IMaterialTypeRepository materialTypeRepository,
                                         MaterialTypeBusinessRules materialTypeBusinessRules)
        {
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
            _materialTypeBusinessRules = materialTypeBusinessRules;
        }

        public async Task<CreatedMaterialTypeResponse> Handle(CreateMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            MaterialType materialType = _mapper.Map<MaterialType>(request);

            await _materialTypeRepository.AddAsync(materialType);

            CreatedMaterialTypeResponse response = _mapper.Map<CreatedMaterialTypeResponse>(materialType);
            return response;
        }
    }
}