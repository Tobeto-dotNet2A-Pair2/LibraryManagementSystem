using Application.Features.MemberContacts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberContacts;

public class MemberContactManager : IMemberContactService
{
    private readonly IMemberContactRepository _memberContactRepository;
    private readonly MemberContactBusinessRules _memberContactBusinessRules;

    public MemberContactManager(IMemberContactRepository memberContactRepository, MemberContactBusinessRules memberContactBusinessRules)
    {
        _memberContactRepository = memberContactRepository;
        _memberContactBusinessRules = memberContactBusinessRules;
    }

    public async Task<MemberContact?> GetAsync(
        Expression<Func<MemberContact, bool>> predicate,
        Func<IQueryable<MemberContact>, IIncludableQueryable<MemberContact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MemberContact? memberContact = await _memberContactRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return memberContact;
    }

    public async Task<IPaginate<MemberContact>?> GetListAsync(
        Expression<Func<MemberContact, bool>>? predicate = null,
        Func<IQueryable<MemberContact>, IOrderedQueryable<MemberContact>>? orderBy = null,
        Func<IQueryable<MemberContact>, IIncludableQueryable<MemberContact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MemberContact> memberContactList = await _memberContactRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return memberContactList;
    }

    public async Task<MemberContact> AddAsync(MemberContact memberContact)
    {
        MemberContact addedMemberContact = await _memberContactRepository.AddAsync(memberContact);

        return addedMemberContact;
    }

    public async Task<MemberContact> UpdateAsync(MemberContact memberContact)
    {
        MemberContact updatedMemberContact = await _memberContactRepository.UpdateAsync(memberContact);

        return updatedMemberContact;
    }

    public async Task<MemberContact> DeleteAsync(MemberContact memberContact, bool permanent = false)
    {
        MemberContact deletedMemberContact = await _memberContactRepository.DeleteAsync(memberContact);

        return deletedMemberContact;
    }
}
