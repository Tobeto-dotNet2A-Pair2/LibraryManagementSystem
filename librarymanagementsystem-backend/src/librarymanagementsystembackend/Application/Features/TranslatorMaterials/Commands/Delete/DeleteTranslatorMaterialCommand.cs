using Application.Features.TranslatorMaterials.Constants;
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

namespace Application.Features.TranslatorMaterials.Commands.Delete;

public class DeleteTranslatorMaterialCommand : IRequest<DeletedTranslatorMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TranslatorMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTranslatorMaterials"];

    public class DeleteTranslatorMaterialCommandHandler : IRequestHandler<DeleteTranslatorMaterialCommand, DeletedTranslatorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
        private readonly TranslatorMaterialBusinessRules _translatorMaterialBusinessRules;

        public DeleteTranslatorMaterialCommandHandler(IMapper mapper, ITranslatorMaterialRepository translatorMaterialRepository,
                                         TranslatorMaterialBusinessRules translatorMaterialBusinessRules)
        {
            _mapper = mapper;
            _translatorMaterialRepository = translatorMaterialRepository;
            _translatorMaterialBusinessRules = translatorMaterialBusinessRules;
        }

        public async Task<DeletedTranslatorMaterialResponse> Handle(DeleteTranslatorMaterialCommand request, CancellationToken cancellationToken)
        {
            TranslatorMaterial? translatorMaterial = await _translatorMaterialRepository.GetAsync(predicate: tm => tm.Id == request.Id, cancellationToken: cancellationToken);
            await _translatorMaterialBusinessRules.TranslatorMaterialShouldExistWhenSelected(translatorMaterial);

            await _translatorMaterialRepository.DeleteAsync(translatorMaterial!);

            DeletedTranslatorMaterialResponse response = _mapper.Map<DeletedTranslatorMaterialResponse>(translatorMaterial);
            return response;
        }
    }
}