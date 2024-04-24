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

namespace Application.Features.MaterialTypes.Commands.Update;

public class UpdateMaterialTypeCommand : IRequest<UpdatedMaterialTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }

    public string[] Roles => [Admin, Write, MaterialTypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialTypes"];

    public class UpdateMaterialTypeCommandHandler : IRequestHandler<UpdateMaterialTypeCommand, UpdatedMaterialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly MaterialTypeBusinessRules _materialTypeBusinessRules;

        public UpdateMaterialTypeCommandHandler(IMapper mapper, IMaterialTypeRepository materialTypeRepository,
                                         MaterialTypeBusinessRules materialTypeBusinessRules)
        {
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
            _materialTypeBusinessRules = materialTypeBusinessRules;
        }

        public async Task<UpdatedMaterialTypeResponse> Handle(UpdateMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            MaterialType? materialType = await _materialTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _materialTypeBusinessRules.MaterialTypeShouldExistWhenSelected(materialType);
            materialType = _mapper.Map(request, materialType);

            await _materialTypeRepository.UpdateAsync(materialType!);

            UpdatedMaterialTypeResponse response = _mapper.Map<UpdatedMaterialTypeResponse>(materialType);
            return response;
        }
    }
}