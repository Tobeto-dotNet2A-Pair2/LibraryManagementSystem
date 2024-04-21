using Application.Features.TranslatorMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TranslatorMaterials;

public class TranslatorMaterialManager : ITranslatorMaterialService
{
    private readonly ITranslatorMaterialRepository _translatorMaterialRepository;
    private readonly TranslatorMaterialBusinessRules _translatorMaterialBusinessRules;

    public TranslatorMaterialManager(ITranslatorMaterialRepository translatorMaterialRepository, TranslatorMaterialBusinessRules translatorMaterialBusinessRules)
    {
        _translatorMaterialRepository = translatorMaterialRepository;
        _translatorMaterialBusinessRules = translatorMaterialBusinessRules;
    }

    public async Task<TranslatorMaterial?> GetAsync(
        Expression<Func<TranslatorMaterial, bool>> predicate,
        Func<IQueryable<TranslatorMaterial>, IIncludableQueryable<TranslatorMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TranslatorMaterial? translatorMaterial = await _translatorMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return translatorMaterial;
    }

    public async Task<IPaginate<TranslatorMaterial>?> GetListAsync(
        Expression<Func<TranslatorMaterial, bool>>? predicate = null,
        Func<IQueryable<TranslatorMaterial>, IOrderedQueryable<TranslatorMaterial>>? orderBy = null,
        Func<IQueryable<TranslatorMaterial>, IIncludableQueryable<TranslatorMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TranslatorMaterial> translatorMaterialList = await _translatorMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return translatorMaterialList;
    }

    public async Task<TranslatorMaterial> AddAsync(TranslatorMaterial translatorMaterial)
    {
        TranslatorMaterial addedTranslatorMaterial = await _translatorMaterialRepository.AddAsync(translatorMaterial);

        return addedTranslatorMaterial;
    }

    public async Task<TranslatorMaterial> UpdateAsync(TranslatorMaterial translatorMaterial)
    {
        TranslatorMaterial updatedTranslatorMaterial = await _translatorMaterialRepository.UpdateAsync(translatorMaterial);

        return updatedTranslatorMaterial;
    }

    public async Task<TranslatorMaterial> DeleteAsync(TranslatorMaterial translatorMaterial, bool permanent = false)
    {
        TranslatorMaterial deletedTranslatorMaterial = await _translatorMaterialRepository.DeleteAsync(translatorMaterial);

        return deletedTranslatorMaterial;
    }
}
