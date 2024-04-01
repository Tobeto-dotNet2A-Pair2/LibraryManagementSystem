using Application.Features.Penalties.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Penalties;

public class PenaltyManager : IPenaltyService
{
    private readonly IPenaltyRepository _penaltyRepository;
    private readonly PenaltyBusinessRules _penaltyBusinessRules;

    public PenaltyManager(IPenaltyRepository penaltyRepository, PenaltyBusinessRules penaltyBusinessRules)
    {
        _penaltyRepository = penaltyRepository;
        _penaltyBusinessRules = penaltyBusinessRules;
    }

    public async Task<Penalty?> GetAsync(
        Expression<Func<Penalty, bool>> predicate,
        Func<IQueryable<Penalty>, IIncludableQueryable<Penalty, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Penalty? penalty = await _penaltyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return penalty;
    }

    public async Task<IPaginate<Penalty>?> GetListAsync(
        Expression<Func<Penalty, bool>>? predicate = null,
        Func<IQueryable<Penalty>, IOrderedQueryable<Penalty>>? orderBy = null,
        Func<IQueryable<Penalty>, IIncludableQueryable<Penalty, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Penalty> penaltyList = await _penaltyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return penaltyList;
    }

    public async Task<Penalty> AddAsync(Penalty penalty)
    {
        Penalty addedPenalty = await _penaltyRepository.AddAsync(penalty);

        return addedPenalty;
    }

    public async Task<Penalty> UpdateAsync(Penalty penalty)
    {
        Penalty updatedPenalty = await _penaltyRepository.UpdateAsync(penalty);

        return updatedPenalty;
    }

    public async Task<Penalty> DeleteAsync(Penalty penalty, bool permanent = false)
    {
        Penalty deletedPenalty = await _penaltyRepository.DeleteAsync(penalty);

        return deletedPenalty;
    }
}
