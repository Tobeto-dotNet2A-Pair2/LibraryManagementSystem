using Application.Features.MaterialPropertyValues.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialPropertyValues.Constants.MaterialPropertyValuesOperationClaims;

namespace Application.Features.MaterialPropertyValues.Queries.GetList;

public class GetListMaterialPropertyValueQuery : IRequest<GetListResponse<GetListMaterialPropertyValueListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialPropertyValues({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialPropertyValues";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialPropertyValueQueryHandler : IRequestHandler<GetListMaterialPropertyValueQuery, GetListResponse<GetListMaterialPropertyValueListItemDto>>
    {
        private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
        private readonly IMapper _mapper;

        public GetListMaterialPropertyValueQueryHandler(IMaterialPropertyValueRepository materialPropertyValueRepository, IMapper mapper)
        {
            _materialPropertyValueRepository = materialPropertyValueRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialPropertyValueListItemDto>> Handle(GetListMaterialPropertyValueQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialPropertyValue> materialPropertyValues = await _materialPropertyValueRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialPropertyValueListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialPropertyValueListItemDto>>(materialPropertyValues);
            return response;
        }
    }
}