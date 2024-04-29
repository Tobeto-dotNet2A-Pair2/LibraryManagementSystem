using Application.Features.MemberAddresses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberAddresses;

public class MemberAddressManager : IMemberAddressService
{
    private readonly IMemberAddressRepository _memberAddressRepository;
    private readonly MemberAddressBusinessRules _memberAddressBusinessRules;

    public MemberAddressManager(IMemberAddressRepository memberAddressRepository, MemberAddressBusinessRules memberAddressBusinessRules)
    {
        _memberAddressRepository = memberAddressRepository;
        _memberAddressBusinessRules = memberAddressBusinessRules;
    }

    public async Task<MemberAddress?> GetAsync(
        Expression<Func<MemberAddress, bool>> predicate,
        Func<IQueryable<MemberAddress>, IIncludableQueryable<MemberAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MemberAddress? memberAddress = await _memberAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return memberAddress;
    }

    public async Task<IPaginate<MemberAddress>?> GetListAsync(
        Expression<Func<MemberAddress, bool>>? predicate = null,
        Func<IQueryable<MemberAddress>, IOrderedQueryable<MemberAddress>>? orderBy = null,
        Func<IQueryable<MemberAddress>, IIncludableQueryable<MemberAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MemberAddress> memberAddressList = await _memberAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return memberAddressList;
    }

    public async Task<MemberAddress> AddAsync(MemberAddress memberAddress)
    {
        MemberAddress addedMemberAddress = await _memberAddressRepository.AddAsync(memberAddress);

        return addedMemberAddress;
    }

    public async Task<MemberAddress> UpdateAsync(MemberAddress memberAddress)
    {
        MemberAddress updatedMemberAddress = await _memberAddressRepository.UpdateAsync(memberAddress);

        return updatedMemberAddress;
    }

    public async Task<MemberAddress> DeleteAsync(MemberAddress memberAddress, bool permanent = false)
    {
        MemberAddress deletedMemberAddress = await _memberAddressRepository.DeleteAsync(memberAddress);

        return deletedMemberAddress;
    }
}
