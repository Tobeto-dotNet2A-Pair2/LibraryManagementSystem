using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Dynamic.Core;

namespace Application.Features.Materials.Queries.GetList.GetAllForAdmin;

public class GetAllMaterialListAdminQuery :IRequest<GetListResponse<GetAllMaterialListAdminDto>>, ICachableRequest //ISecuredRequest,
{
    public PageRequest PageRequest { get; set; }
    //public string SearchText { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllMaterialListAdminHandler : IRequestHandler<GetAllMaterialListAdminQuery,GetListResponse<GetAllMaterialListAdminDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        
        public GetAllMaterialListAdminHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetAllMaterialListAdminDto>> Handle(GetAllMaterialListAdminQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Material> materials = await _materialRepository.GetListAsync(
                include: m => m.Include(m => m.MaterialImages), //include MaterialImages 
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
            GetListResponse<GetAllMaterialListAdminDto> response = _mapper.Map<GetListResponse<GetAllMaterialListAdminDto>>(materials);
            return response;
        }

        //public async Task<List<GetAllMaterialListAdminDto>> Handle(GetAllMaterialListAdminQuery request, CancellationToken cancellationToken)
        //{
        //    IQueryable<Material> query = _materialRepository.Query(); 
        //    List<GetAllMaterialListAdminDto> allMaterialListAdmin = await query
        //        .Include(x => x.MaterialImages.Where(a => a.DeletedDate == null))
        //        .Where(x => x.DeletedDate == null)
        //        .OrderByDescending(b=>b.CreatedDate)
        //        .Page(request.PageRequest.PageIndex, request.PageRequest.PageSize)
        //        .ProjectTo<GetAllMaterialListAdminDto>(_mapper.ConfigurationProvider)
        //        .ToListAsync(cancellationToken);

        //    return allMaterialListAdmin;
        //}


    }
}