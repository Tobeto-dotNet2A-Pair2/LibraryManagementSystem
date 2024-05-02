using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using System.Linq.Dynamic.Core;

namespace Application.Features.Materials.Queries.GetList.GetAllForAdmin;

public class GetAllMaterialsForAdminQuery :IRequest<List<GetAllMaterialsForAdminDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetAllMaterialsForAdminHandler : IRequestHandler<GetAllMaterialsForAdminQuery,List<GetAllMaterialsForAdminDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        
        public GetAllMaterialsForAdminHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetAllMaterialsForAdminDto>> Handle(GetAllMaterialsForAdminQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Material> query = _materialRepository.Query(); 
            List<GetAllMaterialsForAdminDto> allMaterialsForAdmin = await query
                .Include(x => x.MaterialImages.Where(a => a.DeletedDate == null))
                .Where(x => x.DeletedDate == null)
                .OrderByDescending(b=>b.CreatedDate)
                .Page(request.PageRequest.PageIndex, request.PageRequest.PageSize)
                .ProjectTo<GetAllMaterialsForAdminDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allMaterialsForAdmin;
        }
    }
}