using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Authors;

public class AuthorManager : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorBusinessRules _authorBusinessRules;

    public AuthorManager(IAuthorRepository authorRepository, AuthorBusinessRules authorBusinessRules)
    {
        _authorRepository = authorRepository;
        _authorBusinessRules = authorBusinessRules;
    }

    public async Task<Author?> GetAsync(
        Expression<Func<Author, bool>> predicate,
        Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Author? author = await _authorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return author;
    }

    public async Task<IPaginate<Author>?> GetListAsync(
        Expression<Func<Author, bool>>? predicate = null,
        Func<IQueryable<Author>, IOrderedQueryable<Author>>? orderBy = null,
        Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Author> authorList = await _authorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorList;
    }

    public async Task<Author> AddAsync(Author author)
    {
        Author addedAuthor = await _authorRepository.AddAsync(author);

        return addedAuthor;
    }

    public async Task<Author> UpdateAsync(Author author)
    {
        Author updatedAuthor = await _authorRepository.UpdateAsync(author);

        return updatedAuthor;
    }

    public async Task<Author> DeleteAsync(Author author, bool permanent = false)
    {
        Author deletedAuthor = await _authorRepository.DeleteAsync(author);

        return deletedAuthor;
    }
}
