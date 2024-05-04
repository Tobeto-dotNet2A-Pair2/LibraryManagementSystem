using Application.Features.BorrowedMaterials.Dtos;
using Application.Features.MaterialCopies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Application.Services.MaterialCopies;

public class MaterialCopyManager : IMaterialCopyService
{
    private readonly IMaterialCopyRepository _materialCopyRepository;
    private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;
    private readonly IMapper _mapper;

    public MaterialCopyManager(IMaterialCopyRepository materialCopyRepository, MaterialCopyBusinessRules materialCopyBusinessRules, IMapper mapper)
    {
        _materialCopyRepository = materialCopyRepository;
        _materialCopyBusinessRules = materialCopyBusinessRules;
        _mapper = mapper;
    }

    public async Task<MaterialCopy?> GetAsync(
        Expression<Func<MaterialCopy, bool>> predicate,
        Func<IQueryable<MaterialCopy>, IIncludableQueryable<MaterialCopy, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialCopy? materialCopy = await _materialCopyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialCopy;
    }

    public async Task<IPaginate<MaterialCopy>?> GetListAsync(
        Expression<Func<MaterialCopy, bool>>? predicate = null,
        Func<IQueryable<MaterialCopy>, IOrderedQueryable<MaterialCopy>>? orderBy = null,
        Func<IQueryable<MaterialCopy>, IIncludableQueryable<MaterialCopy, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialCopy> materialCopyList = await _materialCopyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialCopyList;
    }

    public async Task<MaterialCopy> AddAsync(MaterialCopy materialCopy)
    {
        MaterialCopy addedMaterialCopy = await _materialCopyRepository.AddAsync(materialCopy);

        return addedMaterialCopy;
    }

    public async Task<MaterialCopy> UpdateAsync(MaterialCopy materialCopy)
    {
        MaterialCopy updatedMaterialCopy = await _materialCopyRepository.UpdateAsync(materialCopy);

        return updatedMaterialCopy;
    }

    public async Task<MaterialCopy> DeleteAsync(MaterialCopy materialCopy, bool permanent = false)
    {
        MaterialCopy deletedMaterialCopy = await _materialCopyRepository.DeleteAsync(materialCopy);

        return deletedMaterialCopy;
    }

    public async Task<GetForBorrowDto> GetForBorrow(Guid id)
    {
        GetForBorrowDto? materialCopyForBorrow = await _materialCopyRepository.Query()
            .Include(a => a.Material)
            .ProjectTo<GetForBorrowDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(a => a.Id == id);
        
        return materialCopyForBorrow!;
    }

    public async Task UpdateAfterRefund(Guid materialCopyId)
    {
      MaterialCopy materialCopy = await _materialCopyRepository.GetAsync(a => a.Id == materialCopyId);

      materialCopy!.IsReserved = false;
      materialCopy!.IsReservable = true;
      materialCopy!.DateReceipt = DateTime.UtcNow;

      await _materialCopyRepository.UpdateAsync(materialCopy);

    }
}
