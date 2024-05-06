using Application.Features.LanguageMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.LanguageMaterials.Constants.LanguageMaterialsOperationClaims;

namespace Application.Features.LanguageMaterials.Queries.GetList;

public class GetListLanguageMaterialQuery : IRequest<GetListResponse<GetListLanguageMaterialListItemDto>>, ICachableRequest, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListLanguageMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetLanguageMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLanguageMaterialQueryHandler : IRequestHandler<GetListLanguageMaterialQuery, GetListResponse<GetListLanguageMaterialListItemDto>>
    {
        private readonly ILanguageMaterialRepository _languageMaterialRepository;
        private readonly IMapper _mapper;

        public GetListLanguageMaterialQueryHandler(ILanguageMaterialRepository languageMaterialRepository, IMapper mapper)
        {
            _languageMaterialRepository = languageMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLanguageMaterialListItemDto>> Handle(GetListLanguageMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageMaterial> languageMaterials = await _languageMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLanguageMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListLanguageMaterialListItemDto>>(languageMaterials);
            return response;
        }
    }
}