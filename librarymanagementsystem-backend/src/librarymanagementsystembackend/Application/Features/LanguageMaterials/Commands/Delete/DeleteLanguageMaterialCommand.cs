using Application.Features.LanguageMaterials.Constants;
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

namespace Application.Features.LanguageMaterials.Commands.Delete;

public class DeleteLanguageMaterialCommand : IRequest<DeletedLanguageMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, LanguageMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLanguageMaterials"];

    public class DeleteLanguageMaterialCommandHandler : IRequestHandler<DeleteLanguageMaterialCommand, DeletedLanguageMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageMaterialRepository _languageMaterialRepository;
        private readonly LanguageMaterialBusinessRules _languageMaterialBusinessRules;

        public DeleteLanguageMaterialCommandHandler(IMapper mapper, ILanguageMaterialRepository languageMaterialRepository,
                                         LanguageMaterialBusinessRules languageMaterialBusinessRules)
        {
            _mapper = mapper;
            _languageMaterialRepository = languageMaterialRepository;
            _languageMaterialBusinessRules = languageMaterialBusinessRules;
        }

        public async Task<DeletedLanguageMaterialResponse> Handle(DeleteLanguageMaterialCommand request, CancellationToken cancellationToken)
        {
            LanguageMaterial? languageMaterial = await _languageMaterialRepository.GetAsync(predicate: lm => lm.Id == request.Id, cancellationToken: cancellationToken);
            await _languageMaterialBusinessRules.LanguageMaterialShouldExistWhenSelected(languageMaterial);

            await _languageMaterialRepository.DeleteAsync(languageMaterial!);

            DeletedLanguageMaterialResponse response = _mapper.Map<DeletedLanguageMaterialResponse>(languageMaterial);
            return response;
        }
    }
}