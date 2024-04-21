using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberAddresses;

public interface IMemberAddressService
{
    Task<MemberAddress?> GetAsync(
        Expression<Func<MemberAddress, bool>> predicate,
        Func<IQueryable<MemberAddress>, IIncludableQueryable<MemberAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MemberAddress>?> GetListAsync(
        Expression<Func<MemberAddress, bool>>? predicate = null,
        Func<IQueryable<MemberAddress>, IOrderedQueryable<MemberAddress>>? orderBy = null,
        Func<IQueryable<MemberAddress>, IIncludableQueryable<MemberAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MemberAddress> AddAsync(MemberAddress memberAddress);
    Task<MemberAddress> UpdateAsync(MemberAddress memberAddress);
    Task<MemberAddress> DeleteAsync(MemberAddress memberAddress, bool permanent = false);
}
