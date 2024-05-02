using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaterialProperties.Queries.GetList.GetListAll;

public class GetListAllMaterialPropertyQuery : IRequest<List<GetListAllMaterialPropertyDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAllMaterialProperties";
    public string? CacheGroupKey => "GetMaterialProperties";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListAllMaterialPropertyHandler : IRequestHandler<GetListAllMaterialPropertyQuery,List<GetListAllMaterialPropertyDto>>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;
        
        public GetListAllMaterialPropertyHandler(IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetListAllMaterialPropertyDto>> Handle(GetListAllMaterialPropertyQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MaterialProperty> query = _materialPropertyRepository.Query();
            List<GetListAllMaterialPropertyDto> allMaterialProperties = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetListAllMaterialPropertyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allMaterialProperties;
        }
    }
}