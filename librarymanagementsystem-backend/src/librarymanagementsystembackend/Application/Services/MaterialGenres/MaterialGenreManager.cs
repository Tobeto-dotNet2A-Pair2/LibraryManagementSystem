using Application.Features.MaterialGenres.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialGenres;

public class MaterialGenreManager : IMaterialGenreService
{
    private readonly IMaterialGenreRepository _materialGenreRepository;
    private readonly MaterialGenreBusinessRules _materialGenreBusinessRules;

    public MaterialGenreManager(IMaterialGenreRepository materialGenreRepository, MaterialGenreBusinessRules materialGenreBusinessRules)
    {
        _materialGenreRepository = materialGenreRepository;
        _materialGenreBusinessRules = materialGenreBusinessRules;
    }

    public async Task<MaterialGenre?> GetAsync(
        Expression<Func<MaterialGenre, bool>> predicate,
        Func<IQueryable<MaterialGenre>, IIncludableQueryable<MaterialGenre, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialGenre? materialGenre = await _materialGenreRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialGenre;
    }

    public async Task<IPaginate<MaterialGenre>?> GetListAsync(
        Expression<Func<MaterialGenre, bool>>? predicate = null,
        Func<IQueryable<MaterialGenre>, IOrderedQueryable<MaterialGenre>>? orderBy = null,
        Func<IQueryable<MaterialGenre>, IIncludableQueryable<MaterialGenre, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialGenre> materialGenreList = await _materialGenreRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialGenreList;
    }

    public async Task<MaterialGenre> AddAsync(MaterialGenre materialGenre)
    {
        MaterialGenre addedMaterialGenre = await _materialGenreRepository.AddAsync(materialGenre);

        return addedMaterialGenre;
    }

    public async Task<MaterialGenre> UpdateAsync(MaterialGenre materialGenre)
    {
        MaterialGenre updatedMaterialGenre = await _materialGenreRepository.UpdateAsync(materialGenre);

        return updatedMaterialGenre;
    }

    public async Task<MaterialGenre> DeleteAsync(MaterialGenre materialGenre, bool permanent = false)
    {
        MaterialGenre deletedMaterialGenre = await _materialGenreRepository.DeleteAsync(materialGenre);

        return deletedMaterialGenre;
    }
}
