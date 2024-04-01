using Application.Features.Translators.Constants;
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

namespace Application.Features.Translators.Commands.Delete;

public class DeleteTranslatorCommand : IRequest<DeletedTranslatorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TranslatorsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTranslators"];

    public class DeleteTranslatorCommandHandler : IRequestHandler<DeleteTranslatorCommand, DeletedTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly TranslatorBusinessRules _translatorBusinessRules;

        public DeleteTranslatorCommandHandler(IMapper mapper, ITranslatorRepository translatorRepository,
                                         TranslatorBusinessRules translatorBusinessRules)
        {
            _mapper = mapper;
            _translatorRepository = translatorRepository;
            _translatorBusinessRules = translatorBusinessRules;
        }

        public async Task<DeletedTranslatorResponse> Handle(DeleteTranslatorCommand request, CancellationToken cancellationToken)
        {
            Translator? translator = await _translatorRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _translatorBusinessRules.TranslatorShouldExistWhenSelected(translator);

            await _translatorRepository.DeleteAsync(translator!);

            DeletedTranslatorResponse response = _mapper.Map<DeletedTranslatorResponse>(translator);
            return response;
        }
    }
}