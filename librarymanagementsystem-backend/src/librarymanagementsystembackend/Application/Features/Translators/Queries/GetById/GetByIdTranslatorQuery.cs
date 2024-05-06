using Application.Features.Translators.Constants;
using Application.Features.Translators.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Translators.Constants.TranslatorsOperationClaims;

namespace Application.Features.Translators.Queries.GetById;

public class GetByIdTranslatorQuery : IRequest<GetByIdTranslatorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTranslatorQueryHandler : IRequestHandler<GetByIdTranslatorQuery, GetByIdTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly TranslatorBusinessRules _translatorBusinessRules;

        public GetByIdTranslatorQueryHandler(IMapper mapper, ITranslatorRepository translatorRepository, TranslatorBusinessRules translatorBusinessRules)
        {
            _mapper = mapper;
            _translatorRepository = translatorRepository;
            _translatorBusinessRules = translatorBusinessRules;
        }

        public async Task<GetByIdTranslatorResponse> Handle(GetByIdTranslatorQuery request, CancellationToken cancellationToken)
        {
            Translator? translator = await _translatorRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _translatorBusinessRules.TranslatorShouldExistWhenSelected(translator);

            GetByIdTranslatorResponse response = _mapper.Map<GetByIdTranslatorResponse>(translator);
            return response;
        }
    }
}