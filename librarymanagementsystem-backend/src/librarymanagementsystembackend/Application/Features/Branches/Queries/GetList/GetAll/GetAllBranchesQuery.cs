using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Branches.Queries.GetList.GetAll;
public class GetAllBranchesQuery : IRequest<List<GetAllBranchesDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllBranches";
    public string? CacheGroupKey => "GetBranches";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery, List<GetAllBranchesDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetAllBranchesHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBranchesDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Branch> query = _branchRepository.Query();
            List<GetAllBranchesDto> allBranches = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllBranchesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allBranches;
        }
    }
}