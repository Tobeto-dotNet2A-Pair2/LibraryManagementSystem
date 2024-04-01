using Application.Features.Members.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Members;

public class MemberManager : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly MemberBusinessRules _memberBusinessRules;

    public MemberManager(IMemberRepository memberRepository, MemberBusinessRules memberBusinessRules)
    {
        _memberRepository = memberRepository;
        _memberBusinessRules = memberBusinessRules;
    }

    public async Task<Member?> GetAsync(
        Expression<Func<Member, bool>> predicate,
        Func<IQueryable<Member>, IIncludableQueryable<Member, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Member? member = await _memberRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return member;
    }

    public async Task<IPaginate<Member>?> GetListAsync(
        Expression<Func<Member, bool>>? predicate = null,
        Func<IQueryable<Member>, IOrderedQueryable<Member>>? orderBy = null,
        Func<IQueryable<Member>, IIncludableQueryable<Member, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Member> memberList = await _memberRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return memberList;
    }

    public async Task<Member> AddAsync(Member member)
    {
        Member addedMember = await _memberRepository.AddAsync(member);

        return addedMember;
    }

    public async Task<Member> UpdateAsync(Member member)
    {
        Member updatedMember = await _memberRepository.UpdateAsync(member);

        return updatedMember;
    }

    public async Task<Member> DeleteAsync(Member member, bool permanent = false)
    {
        Member deletedMember = await _memberRepository.DeleteAsync(member);

        return deletedMember;
    }
}
