using Application.Features.LanguageMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LanguageMaterials;

public class LanguageMaterialManager : ILanguageMaterialService
{
    private readonly ILanguageMaterialRepository _languageMaterialRepository;
    private readonly LanguageMaterialBusinessRules _languageMaterialBusinessRules;

    public LanguageMaterialManager(ILanguageMaterialRepository languageMaterialRepository, LanguageMaterialBusinessRules languageMaterialBusinessRules)
    {
        _languageMaterialRepository = languageMaterialRepository;
        _languageMaterialBusinessRules = languageMaterialBusinessRules;
    }

    public async Task<LanguageMaterial?> GetAsync(
        Expression<Func<LanguageMaterial, bool>> predicate,
        Func<IQueryable<LanguageMaterial>, IIncludableQueryable<LanguageMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LanguageMaterial? languageMaterial = await _languageMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return languageMaterial;
    }

    public async Task<IPaginate<LanguageMaterial>?> GetListAsync(
        Expression<Func<LanguageMaterial, bool>>? predicate = null,
        Func<IQueryable<LanguageMaterial>, IOrderedQueryable<LanguageMaterial>>? orderBy = null,
        Func<IQueryable<LanguageMaterial>, IIncludableQueryable<LanguageMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LanguageMaterial> languageMaterialList = await _languageMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return languageMaterialList;
    }

    public async Task<LanguageMaterial> AddAsync(LanguageMaterial languageMaterial)
    {
        LanguageMaterial addedLanguageMaterial = await _languageMaterialRepository.AddAsync(languageMaterial);

        return addedLanguageMaterial;
    }

    public async Task<LanguageMaterial> UpdateAsync(LanguageMaterial languageMaterial)
    {
        LanguageMaterial updatedLanguageMaterial = await _languageMaterialRepository.UpdateAsync(languageMaterial);

        return updatedLanguageMaterial;
    }

    public async Task<LanguageMaterial> DeleteAsync(LanguageMaterial languageMaterial, bool permanent = false)
    {
        LanguageMaterial deletedLanguageMaterial = await _languageMaterialRepository.DeleteAsync(languageMaterial);

        return deletedLanguageMaterial;
    }
}
