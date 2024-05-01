using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Application.Features.Materials.Queries.GetList.GetAll;
public class GetAllMaterialsQuery : IRequest<List<GetAllMaterialsDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllMaterialsQuery";
    public string? CacheGroupKey => "GetMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, List<GetAllMaterialsDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialsQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllMaterialsDto>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Material> query = _materialRepository.Query();
            List<GetAllMaterialsDto> allMaterials = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllMaterialsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allMaterials;
        }
    }
}
