using Application.Features.TranslatorMaterials.Constants;
using Application.Features.TranslatorMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TranslatorMaterials.Constants.TranslatorMaterialsOperationClaims;

namespace Application.Features.TranslatorMaterials.Commands.Create;

public class CreateTranslatorMaterialCommand : IRequest<CreatedTranslatorMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, TranslatorMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTranslatorMaterials"];

    public class CreateTranslatorMaterialCommandHandler : IRequestHandler<CreateTranslatorMaterialCommand, CreatedTranslatorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
        private readonly TranslatorMaterialBusinessRules _translatorMaterialBusinessRules;

        public CreateTranslatorMaterialCommandHandler(IMapper mapper, ITranslatorMaterialRepository translatorMaterialRepository,
                                         TranslatorMaterialBusinessRules translatorMaterialBusinessRules)
        {
            _mapper = mapper;
            _translatorMaterialRepository = translatorMaterialRepository;
            _translatorMaterialBusinessRules = translatorMaterialBusinessRules;
        }

        public async Task<CreatedTranslatorMaterialResponse> Handle(CreateTranslatorMaterialCommand request, CancellationToken cancellationToken)
        {
            TranslatorMaterial translatorMaterial = _mapper.Map<TranslatorMaterial>(request);

            await _translatorMaterialRepository.AddAsync(translatorMaterial);

            CreatedTranslatorMaterialResponse response = _mapper.Map<CreatedTranslatorMaterialResponse>(translatorMaterial);
            return response;
        }
    }
}