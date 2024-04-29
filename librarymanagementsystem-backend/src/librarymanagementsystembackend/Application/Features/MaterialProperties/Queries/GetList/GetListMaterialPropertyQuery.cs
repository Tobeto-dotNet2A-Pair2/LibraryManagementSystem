using Application.Features.MaterialProperties.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialProperties.Constants.MaterialPropertiesOperationClaims;

namespace Application.Features.MaterialProperties.Queries.GetList;

public class GetListMaterialPropertyQuery : IRequest<GetListResponse<GetListMaterialPropertyListItemDto>>, ICachableRequest // ISecuredRequest,
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialProperties({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialProperties";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialPropertyQueryHandler : IRequestHandler<GetListMaterialPropertyQuery, GetListResponse<GetListMaterialPropertyListItemDto>>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;

        public GetListMaterialPropertyQueryHandler(IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialPropertyListItemDto>> Handle(GetListMaterialPropertyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialProperty> materialProperties = await _materialPropertyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialPropertyListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialPropertyListItemDto>>(materialProperties);
            return response;
        }
    }
}