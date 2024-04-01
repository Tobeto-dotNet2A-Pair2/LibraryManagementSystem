using Application.Features.MaterialTypes.Constants;
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

namespace Application.Features.MaterialTypes.Commands.Delete;

public class DeleteMaterialTypeCommand : IRequest<DeletedMaterialTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialTypesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialTypes"];

    public class DeleteMaterialTypeCommandHandler : IRequestHandler<DeleteMaterialTypeCommand, DeletedMaterialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly MaterialTypeBusinessRules _materialTypeBusinessRules;

        public DeleteMaterialTypeCommandHandler(IMapper mapper, IMaterialTypeRepository materialTypeRepository,
                                         MaterialTypeBusinessRules materialTypeBusinessRules)
        {
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
            _materialTypeBusinessRules = materialTypeBusinessRules;
        }

        public async Task<DeletedMaterialTypeResponse> Handle(DeleteMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            MaterialType? materialType = await _materialTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _materialTypeBusinessRules.MaterialTypeShouldExistWhenSelected(materialType);

            await _materialTypeRepository.DeleteAsync(materialType!);

            DeletedMaterialTypeResponse response = _mapper.Map<DeletedMaterialTypeResponse>(materialType);
            return response;
        }
    }
}