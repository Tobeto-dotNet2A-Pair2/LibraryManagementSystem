using Application.Features.Translators.Constants;
using Application.Features.Translators.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Translators.Constants.TranslatorsOperationClaims;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommand : IRequest<CreatedTranslatorResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, TranslatorsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTranslators"];

    public class CreateTranslatorCommandHandler : IRequestHandler<CreateTranslatorCommand, CreatedTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly TranslatorBusinessRules _translatorBusinessRules;

        public CreateTranslatorCommandHandler(IMapper mapper, ITranslatorRepository translatorRepository,
                                         TranslatorBusinessRules translatorBusinessRules)
        {
            _mapper = mapper;
            _translatorRepository = translatorRepository;
            _translatorBusinessRules = translatorBusinessRules;
        }

        public async Task<CreatedTranslatorResponse> Handle(CreateTranslatorCommand request, CancellationToken cancellationToken)
        {
            Translator translator = _mapper.Map<Translator>(request);

            await _translatorRepository.AddAsync(translator);

            CreatedTranslatorResponse response = _mapper.Map<CreatedTranslatorResponse>(translator);
            return response;
        }
    }
}