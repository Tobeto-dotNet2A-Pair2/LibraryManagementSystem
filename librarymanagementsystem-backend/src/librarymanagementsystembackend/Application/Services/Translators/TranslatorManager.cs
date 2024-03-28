using Application.Features.Translators.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Translators;

public class TranslatorManager : ITranslatorService
{
    private readonly ITranslatorRepository _translatorRepository;
    private readonly TranslatorBusinessRules _translatorBusinessRules;

    public TranslatorManager(ITranslatorRepository translatorRepository, TranslatorBusinessRules translatorBusinessRules)
    {
        _translatorRepository = translatorRepository;
        _translatorBusinessRules = translatorBusinessRules;
    }

    public async Task<Translator?> GetAsync(
        Expression<Func<Translator, bool>> predicate,
        Func<IQueryable<Translator>, IIncludableQueryable<Translator, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Translator? translator = await _translatorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return translator;
    }

    public async Task<IPaginate<Translator>?> GetListAsync(
        Expression<Func<Translator, bool>>? predicate = null,
        Func<IQueryable<Translator>, IOrderedQueryable<Translator>>? orderBy = null,
        Func<IQueryable<Translator>, IIncludableQueryable<Translator, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Translator> translatorList = await _translatorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return translatorList;
    }

    public async Task<Translator> AddAsync(Translator translator)
    {
        Translator addedTranslator = await _translatorRepository.AddAsync(translator);

        return addedTranslator;
    }

    public async Task<Translator> UpdateAsync(Translator translator)
    {
        Translator updatedTranslator = await _translatorRepository.UpdateAsync(translator);

        return updatedTranslator;
    }

    public async Task<Translator> DeleteAsync(Translator translator, bool permanent = false)
    {
        Translator deletedTranslator = await _translatorRepository.DeleteAsync(translator);

        return deletedTranslator;
    }
}
