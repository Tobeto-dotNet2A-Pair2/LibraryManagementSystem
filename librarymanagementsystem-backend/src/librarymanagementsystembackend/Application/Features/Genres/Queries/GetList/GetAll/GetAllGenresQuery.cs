using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Genres.Queries.GetList.GetAll;
public class GetAllGenresQuery : IRequest<List<GetAllGenresDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllGenres";
    public string? CacheGroupKey => "GetGenres";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, List<GetAllGenresDto>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetAllGenresHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllGenresDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Genre> query = _genreRepository.Query();
            List<GetAllGenresDto> allGenres = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllGenresDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allGenres;
        }
    }
}