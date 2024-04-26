using Application.Features.TranslatorMaterials.Constants;
using Application.Features.TranslatorMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TranslatorMaterials.Constants.TranslatorMaterialsOperationClaims;

namespace Application.Features.TranslatorMaterials.Queries.GetById;

public class GetByIdTranslatorMaterialQuery : IRequest<GetByIdTranslatorMaterialResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTranslatorMaterialQueryHandler : IRequestHandler<GetByIdTranslatorMaterialQuery, GetByIdTranslatorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
        private readonly TranslatorMaterialBusinessRules _translatorMaterialBusinessRules;

        public GetByIdTranslatorMaterialQueryHandler(IMapper mapper, ITranslatorMaterialRepository translatorMaterialRepository, TranslatorMaterialBusinessRules translatorMaterialBusinessRules)
        {
            _mapper = mapper;
            _translatorMaterialRepository = translatorMaterialRepository;
            _translatorMaterialBusinessRules = translatorMaterialBusinessRules;
        }

        public async Task<GetByIdTranslatorMaterialResponse> Handle(GetByIdTranslatorMaterialQuery request, CancellationToken cancellationToken)
        {
            TranslatorMaterial? translatorMaterial = await _translatorMaterialRepository.GetAsync(predicate: tm => tm.Id == request.Id, cancellationToken: cancellationToken);
            await _translatorMaterialBusinessRules.TranslatorMaterialShouldExistWhenSelected(translatorMaterial);

            GetByIdTranslatorMaterialResponse response = _mapper.Map<GetByIdTranslatorMaterialResponse>(translatorMaterial);
            return response;
        }
    }
}