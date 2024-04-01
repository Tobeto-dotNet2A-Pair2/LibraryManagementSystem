using Application.Features.MaterialTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialTypes.Constants.MaterialTypesOperationClaims;

namespace Application.Features.MaterialTypes.Queries.GetList;

public class GetListMaterialTypeQuery : IRequest<GetListResponse<GetListMaterialTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialTypeQueryHandler : IRequestHandler<GetListMaterialTypeQuery, GetListResponse<GetListMaterialTypeListItemDto>>
    {
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly IMapper _mapper;

        public GetListMaterialTypeQueryHandler(IMaterialTypeRepository materialTypeRepository, IMapper mapper)
        {
            _materialTypeRepository = materialTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialTypeListItemDto>> Handle(GetListMaterialTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialType> materialTypes = await _materialTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialTypeListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialTypeListItemDto>>(materialTypes);
            return response;
        }
    }
}