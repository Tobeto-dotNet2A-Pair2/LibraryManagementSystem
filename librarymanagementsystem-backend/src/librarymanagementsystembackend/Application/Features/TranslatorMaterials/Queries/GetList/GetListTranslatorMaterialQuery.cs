using Application.Features.TranslatorMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TranslatorMaterials.Constants.TranslatorMaterialsOperationClaims;

namespace Application.Features.TranslatorMaterials.Queries.GetList;

public class GetListTranslatorMaterialQuery : IRequest<GetListResponse<GetListTranslatorMaterialListItemDto>>, ICachableRequest, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTranslatorMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTranslatorMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTranslatorMaterialQueryHandler : IRequestHandler<GetListTranslatorMaterialQuery, GetListResponse<GetListTranslatorMaterialListItemDto>>
    {
        private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
        private readonly IMapper _mapper;

        public GetListTranslatorMaterialQueryHandler(ITranslatorMaterialRepository translatorMaterialRepository, IMapper mapper)
        {
            _translatorMaterialRepository = translatorMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTranslatorMaterialListItemDto>> Handle(GetListTranslatorMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TranslatorMaterial> translatorMaterials = await _translatorMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTranslatorMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListTranslatorMaterialListItemDto>>(translatorMaterials);
            return response;
        }
    }
}