using Application.Features.Materials.Constants;
using Application.Features.Materials.Constants;
using Application.Features.Materials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Materials.Constants.MaterialsOperationClaims;

namespace Application.Features.Materials.Commands.Delete;

public class DeleteMaterialCommand : IRequest<DeletedMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterials"];

    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, DeletedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;

        public DeleteMaterialCommandHandler(IMapper mapper, IMaterialRepository materialRepository,
                                         MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }

        public async Task<DeletedMaterialResponse> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            Material? material = await _materialRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _materialBusinessRules.MaterialShouldExistWhenSelected(material);

            await _materialRepository.DeleteAsync(material!);

            DeletedMaterialResponse response = _mapper.Map<DeletedMaterialResponse>(material);
            return response;
        }
    }
}