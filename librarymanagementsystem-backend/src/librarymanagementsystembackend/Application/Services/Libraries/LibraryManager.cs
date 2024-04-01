using Application.Features.Libraries.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Libraries;

public class LibraryManager : ILibraryService
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly LibraryBusinessRules _libraryBusinessRules;

    public LibraryManager(ILibraryRepository libraryRepository, LibraryBusinessRules libraryBusinessRules)
    {
        _libraryRepository = libraryRepository;
        _libraryBusinessRules = libraryBusinessRules;
    }

    public async Task<Library?> GetAsync(
        Expression<Func<Library, bool>> predicate,
        Func<IQueryable<Library>, IIncludableQueryable<Library, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Library? library = await _libraryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return library;
    }

    public async Task<IPaginate<Library>?> GetListAsync(
        Expression<Func<Library, bool>>? predicate = null,
        Func<IQueryable<Library>, IOrderedQueryable<Library>>? orderBy = null,
        Func<IQueryable<Library>, IIncludableQueryable<Library, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Library> libraryList = await _libraryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return libraryList;
    }

    public async Task<Library> AddAsync(Library library)
    {
        Library addedLibrary = await _libraryRepository.AddAsync(library);

        return addedLibrary;
    }

    public async Task<Library> UpdateAsync(Library library)
    {
        Library updatedLibrary = await _libraryRepository.UpdateAsync(library);

        return updatedLibrary;
    }

    public async Task<Library> DeleteAsync(Library library, bool permanent = false)
    {
        Library deletedLibrary = await _libraryRepository.DeleteAsync(library);

        return deletedLibrary;
    }
}
