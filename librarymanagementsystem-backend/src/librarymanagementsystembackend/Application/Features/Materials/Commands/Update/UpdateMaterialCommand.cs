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

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommand : IRequest<UpdatedMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Punishment { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; }

    public string[] Roles => [Admin, Write, MaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterials"];

    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, UpdatedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;

        public UpdateMaterialCommandHandler(IMapper mapper, IMaterialRepository materialRepository,
                                         MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }

        public async Task<UpdatedMaterialResponse> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            Material? material = await _materialRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _materialBusinessRules.MaterialShouldExistWhenSelected(material);
            material = _mapper.Map(request, material);

            await _materialRepository.UpdateAsync(material!);

            UpdatedMaterialResponse response = _mapper.Map<UpdatedMaterialResponse>(material);
            return response;
        }
    }
}