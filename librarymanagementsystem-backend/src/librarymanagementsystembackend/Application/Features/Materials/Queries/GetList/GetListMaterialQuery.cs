using Application.Features.Materials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Materials.Constants.MaterialsOperationClaims;

namespace Application.Features.Materials.Queries.GetList;

public class GetListMaterialQuery : IRequest<GetListResponse<GetListMaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialQueryHandler : IRequestHandler<GetListMaterialQuery, GetListResponse<GetListMaterialListItemDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetListMaterialQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialListItemDto>> Handle(GetListMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Material> materials = await _materialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialListItemDto>>(materials);
            return response;
        }
    }
}