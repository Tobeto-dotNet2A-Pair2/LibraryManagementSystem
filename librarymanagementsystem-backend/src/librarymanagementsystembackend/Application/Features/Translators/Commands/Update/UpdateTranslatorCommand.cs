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

namespace Application.Features.Translators.Commands.Update;

public class UpdateTranslatorCommand : IRequest<UpdatedTranslatorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, TranslatorsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTranslators"];

    public class UpdateTranslatorCommandHandler : IRequestHandler<UpdateTranslatorCommand, UpdatedTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly TranslatorBusinessRules _translatorBusinessRules;

        public UpdateTranslatorCommandHandler(IMapper mapper, ITranslatorRepository translatorRepository,
                                         TranslatorBusinessRules translatorBusinessRules)
        {
            _mapper = mapper;
            _translatorRepository = translatorRepository;
            _translatorBusinessRules = translatorBusinessRules;
        }

        public async Task<UpdatedTranslatorResponse> Handle(UpdateTranslatorCommand request, CancellationToken cancellationToken)
        {
            Translator? translator = await _translatorRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _translatorBusinessRules.TranslatorShouldExistWhenSelected(translator);
            translator = _mapper.Map(request, translator);

            await _translatorRepository.UpdateAsync(translator!);

            UpdatedTranslatorResponse response = _mapper.Map<UpdatedTranslatorResponse>(translator);
            return response;
        }
    }
}