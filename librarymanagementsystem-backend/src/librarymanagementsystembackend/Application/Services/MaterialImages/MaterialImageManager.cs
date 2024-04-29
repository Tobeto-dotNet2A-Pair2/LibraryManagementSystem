using Application.Features.MaterialImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialImages;

public class MaterialImageManager : IMaterialImageService
{
    private readonly IMaterialImageRepository _materialImageRepository;
    private readonly MaterialImageBusinessRules _materialImageBusinessRules;

    public MaterialImageManager(IMaterialImageRepository materialImageRepository, MaterialImageBusinessRules materialImageBusinessRules)
    {
        _materialImageRepository = materialImageRepository;
        _materialImageBusinessRules = materialImageBusinessRules;
    }

    public async Task<MaterialImage?> GetAsync(
        Expression<Func<MaterialImage, bool>> predicate,
        Func<IQueryable<MaterialImage>, IIncludableQueryable<MaterialImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialImage? materialImage = await _materialImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialImage;
    }

    public async Task<IPaginate<MaterialImage>?> GetListAsync(
        Expression<Func<MaterialImage, bool>>? predicate = null,
        Func<IQueryable<MaterialImage>, IOrderedQueryable<MaterialImage>>? orderBy = null,
        Func<IQueryable<MaterialImage>, IIncludableQueryable<MaterialImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialImage> materialImageList = await _materialImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialImageList;
    }

    public async Task<MaterialImage> AddAsync(MaterialImage materialImage)
    {
        MaterialImage addedMaterialImage = await _materialImageRepository.AddAsync(materialImage);

        return addedMaterialImage;
    }

    public async Task<MaterialImage> UpdateAsync(MaterialImage materialImage)
    {
        MaterialImage updatedMaterialImage = await _materialImageRepository.UpdateAsync(materialImage);

        return updatedMaterialImage;
    }

    public async Task<MaterialImage> DeleteAsync(MaterialImage materialImage, bool permanent = false)
    {
        MaterialImage deletedMaterialImage = await _materialImageRepository.DeleteAsync(materialImage);

        return deletedMaterialImage;
    }
}
