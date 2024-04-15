using Application.Features.LanguageMaterials.Constants;
using Application.Features.LanguageMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LanguageMaterials.Constants.LanguageMaterialsOperationClaims;

namespace Application.Features.LanguageMaterials.Commands.Update;

public class UpdateLanguageMaterialCommand : IRequest<UpdatedLanguageMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, LanguageMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLanguageMaterials"];

    public class UpdateLanguageMaterialCommandHandler : IRequestHandler<UpdateLanguageMaterialCommand, UpdatedLanguageMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageMaterialRepository _languageMaterialRepository;
        private readonly LanguageMaterialBusinessRules _languageMaterialBusinessRules;

        public UpdateLanguageMaterialCommandHandler(IMapper mapper, ILanguageMaterialRepository languageMaterialRepository,
                                         LanguageMaterialBusinessRules languageMaterialBusinessRules)
        {
            _mapper = mapper;
            _languageMaterialRepository = languageMaterialRepository;
            _languageMaterialBusinessRules = languageMaterialBusinessRules;
        }

        public async Task<UpdatedLanguageMaterialResponse> Handle(UpdateLanguageMaterialCommand request, CancellationToken cancellationToken)
        {
            LanguageMaterial? languageMaterial = await _languageMaterialRepository.GetAsync(predicate: lm => lm.Id == request.Id, cancellationToken: cancellationToken);
            await _languageMaterialBusinessRules.LanguageMaterialShouldExistWhenSelected(languageMaterial);
            languageMaterial = _mapper.Map(request, languageMaterial);

            await _languageMaterialRepository.UpdateAsync(languageMaterial!);

            UpdatedLanguageMaterialResponse response = _mapper.Map<UpdatedLanguageMaterialResponse>(languageMaterial);
            return response;
        }
    }
}