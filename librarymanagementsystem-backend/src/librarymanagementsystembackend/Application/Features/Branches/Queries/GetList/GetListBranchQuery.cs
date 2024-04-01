using Application.Features.Branches.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Branches.Constants.BranchesOperationClaims;

namespace Application.Features.Branches.Queries.GetList;

public class GetListBranchQuery : IRequest<GetListResponse<GetListBranchListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBranches({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBranches";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBranchQueryHandler : IRequestHandler<GetListBranchQuery, GetListResponse<GetListBranchListItemDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetListBranchQueryHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBranchListItemDto>> Handle(GetListBranchQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Branch> branches = await _branchRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBranchListItemDto> response = _mapper.Map<GetListResponse<GetListBranchListItemDto>>(branches);
            return response;
        }
    }
}