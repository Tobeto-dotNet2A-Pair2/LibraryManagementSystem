using Application.Features.BorrowedMaterials.Dtos;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBorrowedMaterialRepository : IAsyncRepository<BorrowedMaterial, Guid>, IRepository<BorrowedMaterial, Guid>
{
    Task<GetMemberDeptForBorrowedMaterialDto> GetMemberDeptForBorrowedMaterialCopyAsync(Guid memberId,
        Guid materialCopyId, CancellationToken cancellationToken);

}