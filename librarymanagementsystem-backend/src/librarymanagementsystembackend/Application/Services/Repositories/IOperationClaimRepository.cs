using Application.Features.OperationClaims.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int> {

    Task<List<GetByRoleNameDto>> GetByRoleNameAsync(List<string> roleNames);

}

