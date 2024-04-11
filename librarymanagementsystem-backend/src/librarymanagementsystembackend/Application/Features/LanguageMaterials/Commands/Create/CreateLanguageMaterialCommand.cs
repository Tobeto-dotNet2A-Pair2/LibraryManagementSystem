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

namespace Application.Features.LanguageMaterials.Commands.Create;

public class CreateLanguageMaterialCommand : IRequest<CreatedLanguageMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, LanguageMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLanguageMaterials"];

    public class CreateLanguageMaterialCommandHandler : IRequestHandler<CreateLanguageMaterialCommand, CreatedLanguageMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageMaterialRepository _languageMaterialRepository;
        private readonly LanguageMaterialBusinessRules _languageMaterialBusinessRules;

        public CreateLanguageMaterialCommandHandler(IMapper mapper, ILanguageMaterialRepository languageMaterialRepository,
                                         LanguageMaterialBusinessRules languageMaterialBusinessRules)
        {
            _mapper = mapper;
            _languageMaterialRepository = languageMaterialRepository;
            _languageMaterialBusinessRules = languageMaterialBusinessRules;
        }

        public async Task<CreatedLanguageMaterialResponse> Handle(CreateLanguageMaterialCommand request, CancellationToken cancellationToken)
        {
            LanguageMaterial languageMaterial = _mapper.Map<LanguageMaterial>(request);

            await _languageMaterialRepository.AddAsync(languageMaterial);

            CreatedLanguageMaterialResponse response = _mapper.Map<CreatedLanguageMaterialResponse>(languageMaterial);
            return response;
        }
    }
}