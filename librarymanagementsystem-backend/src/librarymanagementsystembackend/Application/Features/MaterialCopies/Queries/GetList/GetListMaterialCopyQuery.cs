using Application.Features.MaterialCopies.Constants;
using Application.Features.MaterialCopies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.MaterialCopies.Constants.MaterialCopiesOperationClaims;

namespace Application.Features.MaterialCopies.Queries.GetList;

public class GetListMaterialCopyQuery : IRequest<GetListResponse<GetListMaterialCopyDto>>, ICachableRequest, ISecuredRequest
{
    public string SearchText { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public class GetListMaterialCopyQueryHandler : IRequestHandler<GetListMaterialCopyQuery, GetListResponse<GetListMaterialCopyDto>>
    {
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly IMapper _mapper;

        public GetListMaterialCopyQueryHandler(IMaterialCopyRepository materialCopyRepository, IMapper mapper)
        {
            _materialCopyRepository = materialCopyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialCopyDto>> Handle(GetListMaterialCopyQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MaterialCopy> query = _materialCopyRepository.Query();
            IPaginate<MaterialCopy> allMaterialCopies = query
                .Include(a=> a.Material).ThenInclude(a=> a.MaterialImages)
                .Include(a=> a.Location)
                .Where(x => x.Material.Name.Contains(request.SearchText))
                .OrderByDescending(b => b.CreatedDate)
                .ToPaginate(request.PageIndex, request.PageSize);

            GetListResponse<GetListMaterialCopyDto> response = _mapper.Map<GetListResponse<GetListMaterialCopyDto>>(allMaterialCopies);
            return response;
        }
    }

    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string CacheGroupKey { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string[] Roles { get; }
}