using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaterialTypes.Queries.GetList.GetAll;
public class GetAllMaterialTypesQuery : IRequest<List<GetAllMaterialTypesDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllMaterialTypes";
    public string? CacheGroupKey => "GetMaterialTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllMaterialTypesHandler : IRequestHandler<GetAllMaterialTypesQuery, List<GetAllMaterialTypesDto>>
    {
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialTypesHandler(IMaterialTypeRepository materialTypeRepository, IMapper mapper)
        {
            _materialTypeRepository = materialTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllMaterialTypesDto>> Handle(GetAllMaterialTypesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MaterialType> query = _materialTypeRepository.Query();
            List<GetAllMaterialTypesDto> allMaterialTypes = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllMaterialTypesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allMaterialTypes;
        }
    }
}