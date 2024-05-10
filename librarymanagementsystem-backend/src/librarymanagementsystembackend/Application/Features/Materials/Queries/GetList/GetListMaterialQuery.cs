using Application.Features.Materials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static Application.Features.Materials.Constants.MaterialsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Materials.Queries.GetList;

public class GetListMaterialQuery : IRequest<GetListResponse<GetListMaterialListItemDto>> , ISecuredRequest //ICachableRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string SearchKey { get; set; }

    public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListMaterials({PageIndex},{PageSize})";
    //public string? CacheGroupKey => "GetMaterials";
    //public TimeSpan? SlidingExpiration { get; }

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
            IPaginate<GetListMaterialListItemDto> materials = _materialRepository.Query()
                .Include(a => a.MaterialCopies)
                .Include(a=> a.MaterialImages)
                .Include(a=> a.AuthorMaterials)
                .Include(a=> a.MaterialPropertyValues)
                .Where(a => a.Name.Contains(request.SearchKey))
                .ProjectTo<GetListMaterialListItemDto>(_mapper.ConfigurationProvider)
                .ToPaginate(request.PageIndex, request.PageSize);
            
            GetListResponse<GetListMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialListItemDto>>(materials);
            return response;
        }
    }
}