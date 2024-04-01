using Application.Features.BorrowedMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BorrowedMaterials.Constants.BorrowedMaterialsOperationClaims;

namespace Application.Features.BorrowedMaterials.Queries.GetList;

public class GetListBorrowedMaterialQuery : IRequest<GetListResponse<GetListBorrowedMaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBorrowedMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBorrowedMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBorrowedMaterialQueryHandler : IRequestHandler<GetListBorrowedMaterialQuery, GetListResponse<GetListBorrowedMaterialListItemDto>>
    {
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly IMapper _mapper;

        public GetListBorrowedMaterialQueryHandler(IBorrowedMaterialRepository borrowedMaterialRepository, IMapper mapper)
        {
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBorrowedMaterialListItemDto>> Handle(GetListBorrowedMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BorrowedMaterial> borrowedMaterials = await _borrowedMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBorrowedMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListBorrowedMaterialListItemDto>>(borrowedMaterials);
            return response;
        }
    }
}