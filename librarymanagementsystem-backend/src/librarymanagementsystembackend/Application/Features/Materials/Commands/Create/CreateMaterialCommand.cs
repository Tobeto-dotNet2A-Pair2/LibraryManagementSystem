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

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommand : IRequest<CreatedMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Punishment { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; }

    public string[] Roles => [Admin, Write, MaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterials"];

    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, CreatedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;

        public CreateMaterialCommandHandler(IMapper mapper, IMaterialRepository materialRepository,
                                         MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }

        public async Task<CreatedMaterialResponse> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            Material material = _mapper.Map<Material>(request);

            await _materialRepository.AddAsync(material);

            CreatedMaterialResponse response = _mapper.Map<CreatedMaterialResponse>(material);
            return response;
        }
    }
}