using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using System.Linq.Dynamic.Core;

namespace Application.Features.Materials.Queries.GetList.GetAllForAdmin;

public class GetAllMaterialListAdminQuery :IRequest<List<GetAllMaterialListAdminDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetAllMaterialListAdminHandler : IRequestHandler<GetAllMaterialListAdminQuery,List<GetAllMaterialListAdminDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        
        public GetAllMaterialListAdminHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetAllMaterialListAdminDto>> Handle(GetAllMaterialListAdminQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Material> query = _materialRepository.Query(); 
            List<GetAllMaterialListAdminDto> allMaterialListAdmin = await query
                .Include(x => x.MaterialImages.Where(a => a.DeletedDate == null))
                .Where(x => x.DeletedDate == null)
                .OrderByDescending(b=>b.CreatedDate)
                .Page(request.PageRequest.PageIndex, request.PageRequest.PageSize)
                .ProjectTo<GetAllMaterialListAdminDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allMaterialListAdmin;
        }
    }
}