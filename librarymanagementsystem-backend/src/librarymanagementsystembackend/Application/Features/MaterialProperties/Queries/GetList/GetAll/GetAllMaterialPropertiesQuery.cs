using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaterialProperties.Queries.GetList.GetAll;
public class GetAllMaterialPropertiesQuery : IRequest<List<GetAllMaterialPropertiesDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllMaterialProperties";
    public string? CacheGroupKey => "GetMaterialProperties";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllMaterialPropertiesHandler : IRequestHandler<GetAllMaterialPropertiesQuery, List<GetAllMaterialPropertiesDto>>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialPropertiesHandler(IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllMaterialPropertiesDto>> Handle(GetAllMaterialPropertiesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MaterialProperty> query = _materialPropertyRepository.Query();
            List<GetAllMaterialPropertiesDto> allMaterialProperties = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllMaterialPropertiesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allMaterialProperties;
        }
    }
}
