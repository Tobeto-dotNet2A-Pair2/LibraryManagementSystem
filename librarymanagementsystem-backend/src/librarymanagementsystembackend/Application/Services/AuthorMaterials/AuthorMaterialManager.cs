using Application.Features.AuthorMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorMaterials;

public class AuthorMaterialManager : IAuthorMaterialService
{
    private readonly IAuthorMaterialRepository _authorMaterialRepository;
    private readonly AuthorMaterialBusinessRules _authorMaterialBusinessRules;

    public AuthorMaterialManager(IAuthorMaterialRepository authorMaterialRepository, AuthorMaterialBusinessRules authorMaterialBusinessRules)
    {
        _authorMaterialRepository = authorMaterialRepository;
        _authorMaterialBusinessRules = authorMaterialBusinessRules;
    }

    public async Task<AuthorMaterial?> GetAsync(
        Expression<Func<AuthorMaterial, bool>> predicate,
        Func<IQueryable<AuthorMaterial>, IIncludableQueryable<AuthorMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorMaterial? authorMaterial = await _authorMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorMaterial;
    }

    public async Task<IPaginate<AuthorMaterial>?> GetListAsync(
        Expression<Func<AuthorMaterial, bool>>? predicate = null,
        Func<IQueryable<AuthorMaterial>, IOrderedQueryable<AuthorMaterial>>? orderBy = null,
        Func<IQueryable<AuthorMaterial>, IIncludableQueryable<AuthorMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorMaterial> authorMaterialList = await _authorMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorMaterialList;
    }

    public async Task<AuthorMaterial> AddAsync(AuthorMaterial authorMaterial)
    {
        AuthorMaterial addedAuthorMaterial = await _authorMaterialRepository.AddAsync(authorMaterial);

        return addedAuthorMaterial;
    }

    public async Task<AuthorMaterial> UpdateAsync(AuthorMaterial authorMaterial)
    {
        AuthorMaterial updatedAuthorMaterial = await _authorMaterialRepository.UpdateAsync(authorMaterial);

        return updatedAuthorMaterial;
    }

    public async Task<AuthorMaterial> DeleteAsync(AuthorMaterial authorMaterial, bool permanent = false)
    {
        AuthorMaterial deletedAuthorMaterial = await _authorMaterialRepository.DeleteAsync(authorMaterial);

        return deletedAuthorMaterial;
    }
}
