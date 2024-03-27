using Application.Features.Branches.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Branches;

public class BranchManager : IBranchService
{
    private readonly IBranchRepository _branchRepository;
    private readonly BranchBusinessRules _branchBusinessRules;

    public BranchManager(IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules)
    {
        _branchRepository = branchRepository;
        _branchBusinessRules = branchBusinessRules;
    }

    public async Task<Branch?> GetAsync(
        Expression<Func<Branch, bool>> predicate,
        Func<IQueryable<Branch>, IIncludableQueryable<Branch, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Branch? branch = await _branchRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return branch;
    }

    public async Task<IPaginate<Branch>?> GetListAsync(
        Expression<Func<Branch, bool>>? predicate = null,
        Func<IQueryable<Branch>, IOrderedQueryable<Branch>>? orderBy = null,
        Func<IQueryable<Branch>, IIncludableQueryable<Branch, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Branch> branchList = await _branchRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return branchList;
    }

    public async Task<Branch> AddAsync(Branch branch)
    {
        Branch addedBranch = await _branchRepository.AddAsync(branch);

        return addedBranch;
    }

    public async Task<Branch> UpdateAsync(Branch branch)
    {
        Branch updatedBranch = await _branchRepository.UpdateAsync(branch);

        return updatedBranch;
    }

    public async Task<Branch> DeleteAsync(Branch branch, bool permanent = false)
    {
        Branch deletedBranch = await _branchRepository.DeleteAsync(branch);

        return deletedBranch;
    }
}
