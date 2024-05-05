using Application.Features.Materials.Queries.GetList.GetAllForAdmin;
using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Dynamic.Core;

namespace Application.Features.Materials.Queries.GetList.GetAllForFrontEnd;

public class GetAllMaterialsForFrontEndQuery : IRequest<GetListResponse<GetAllMaterialsForFrontEndResponse>>
{
    public string SearchText { get; set; }
    
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    
    
    public class GetAllMaterialsForFrontEndHandler : IRequestHandler<GetAllMaterialsForFrontEndQuery,
        GetListResponse<GetAllMaterialsForFrontEndResponse>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        
        public GetAllMaterialsForFrontEndHandler(IMaterialRepository materialRepository,
            IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        
        public async Task<GetListResponse<GetAllMaterialsForFrontEndResponse>> Handle(GetAllMaterialsForFrontEndQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Material> query = _materialRepository.Query();
            IPaginate<Material> allMaterialsForFrontEnd = query
                .Include(x => x.MaterialImages.Where(a => a.DeletedDate == null))
                .Where(x => x.Name.Contains(request.SearchText))
                .OrderByDescending(b => b.CreatedDate)
                .ToPaginate(request.PageIndex, request.PageSize);

            GetListResponse<GetAllMaterialsForFrontEndResponse> response = _mapper.Map<GetListResponse<GetAllMaterialsForFrontEndResponse>>(allMaterialsForFrontEnd);

            return response;

        }
    }
}