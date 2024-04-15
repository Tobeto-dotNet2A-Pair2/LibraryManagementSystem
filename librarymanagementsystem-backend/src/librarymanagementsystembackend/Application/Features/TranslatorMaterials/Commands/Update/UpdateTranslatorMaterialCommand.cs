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

namespace Application.Features.TranslatorMaterials.Commands.Update;

public class UpdateTranslatorMaterialCommand : IRequest<UpdatedTranslatorMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, TranslatorMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTranslatorMaterials"];

    public class UpdateTranslatorMaterialCommandHandler : IRequestHandler<UpdateTranslatorMaterialCommand, UpdatedTranslatorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
        private readonly TranslatorMaterialBusinessRules _translatorMaterialBusinessRules;

        public UpdateTranslatorMaterialCommandHandler(IMapper mapper, ITranslatorMaterialRepository translatorMaterialRepository,
                                         TranslatorMaterialBusinessRules translatorMaterialBusinessRules)
        {
            _mapper = mapper;
            _translatorMaterialRepository = translatorMaterialRepository;
            _translatorMaterialBusinessRules = translatorMaterialBusinessRules;
        }

        public async Task<UpdatedTranslatorMaterialResponse> Handle(UpdateTranslatorMaterialCommand request, CancellationToken cancellationToken)
        {
            TranslatorMaterial? translatorMaterial = await _translatorMaterialRepository.GetAsync(predicate: tm => tm.Id == request.Id, cancellationToken: cancellationToken);
            await _translatorMaterialBusinessRules.TranslatorMaterialShouldExistWhenSelected(translatorMaterial);
            translatorMaterial = _mapper.Map(request, translatorMaterial);

            await _translatorMaterialRepository.UpdateAsync(translatorMaterial!);

            UpdatedTranslatorMaterialResponse response = _mapper.Map<UpdatedTranslatorMaterialResponse>(translatorMaterial);
            return response;
        }
    }
}