using Application.Features.Genres.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Genres;

public class GenreManager : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly GenreBusinessRules _genreBusinessRules;

    public GenreManager(IGenreRepository genreRepository, GenreBusinessRules genreBusinessRules)
    {
        _genreRepository = genreRepository;
        _genreBusinessRules = genreBusinessRules;
    }

    public async Task<Genre?> GetAsync(
        Expression<Func<Genre, bool>> predicate,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Genre? genre = await _genreRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return genre;
    }

    public async Task<IPaginate<Genre>?> GetListAsync(
        Expression<Func<Genre, bool>>? predicate = null,
        Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Genre> genreList = await _genreRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return genreList;
    }

    public async Task<Genre> AddAsync(Genre genre)
    {
        Genre addedGenre = await _genreRepository.AddAsync(genre);

        return addedGenre;
    }

    public async Task<Genre> UpdateAsync(Genre genre)
    {
        Genre updatedGenre = await _genreRepository.UpdateAsync(genre);

        return updatedGenre;
    }

    public async Task<Genre> DeleteAsync(Genre genre, bool permanent = false)
    {
        Genre deletedGenre = await _genreRepository.DeleteAsync(genre);

        return deletedGenre;
    }
}
