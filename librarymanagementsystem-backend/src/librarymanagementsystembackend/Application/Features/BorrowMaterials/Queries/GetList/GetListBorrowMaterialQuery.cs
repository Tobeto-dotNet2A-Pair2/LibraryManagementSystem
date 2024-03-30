using Application.Features.BorrowMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BorrowMaterials.Constants.BorrowMaterialsOperationClaims;

namespace Application.Features.BorrowMaterials.Queries.GetList;

public class GetListBorrowMaterialQuery : IRequest<GetListResponse<GetListBorrowMaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBorrowMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBorrowMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBorrowMaterialQueryHandler : IRequestHandler<GetListBorrowMaterialQuery, GetListResponse<GetListBorrowMaterialListItemDto>>
    {
        private readonly IBorrowMaterialRepository _borrowMaterialRepository;
        private readonly IMapper _mapper;

        public GetListBorrowMaterialQueryHandler(IBorrowMaterialRepository borrowMaterialRepository, IMapper mapper)
        {
            _borrowMaterialRepository = borrowMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBorrowMaterialListItemDto>> Handle(GetListBorrowMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BorrowMaterial> borrowMaterials = await _borrowMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBorrowMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListBorrowMaterialListItemDto>>(borrowMaterials);
            return response;
        }
    }
}