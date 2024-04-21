using Application.Features.LanguageMaterials.Constants;
using Application.Features.LanguageMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LanguageMaterials.Constants.LanguageMaterialsOperationClaims;

namespace Application.Features.LanguageMaterials.Queries.GetById;

public class GetByIdLanguageMaterialQuery : IRequest<GetByIdLanguageMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdLanguageMaterialQueryHandler : IRequestHandler<GetByIdLanguageMaterialQuery, GetByIdLanguageMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageMaterialRepository _languageMaterialRepository;
        private readonly LanguageMaterialBusinessRules _languageMaterialBusinessRules;

        public GetByIdLanguageMaterialQueryHandler(IMapper mapper, ILanguageMaterialRepository languageMaterialRepository, LanguageMaterialBusinessRules languageMaterialBusinessRules)
        {
            _mapper = mapper;
            _languageMaterialRepository = languageMaterialRepository;
            _languageMaterialBusinessRules = languageMaterialBusinessRules;
        }

        public async Task<GetByIdLanguageMaterialResponse> Handle(GetByIdLanguageMaterialQuery request, CancellationToken cancellationToken)
        {
            LanguageMaterial? languageMaterial = await _languageMaterialRepository.GetAsync(predicate: lm => lm.Id == request.Id, cancellationToken: cancellationToken);
            await _languageMaterialBusinessRules.LanguageMaterialShouldExistWhenSelected(languageMaterial);

            GetByIdLanguageMaterialResponse response = _mapper.Map<GetByIdLanguageMaterialResponse>(languageMaterial);
            return response;
        }
    }
}