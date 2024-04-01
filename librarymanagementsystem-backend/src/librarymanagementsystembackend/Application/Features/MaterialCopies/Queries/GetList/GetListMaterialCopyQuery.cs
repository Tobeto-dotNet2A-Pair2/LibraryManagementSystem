using Application.Features.MaterialCopies.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialCopies.Constants.MaterialCopiesOperationClaims;

namespace Application.Features.MaterialCopies.Queries.GetList;

public class GetListMaterialCopyQuery : IRequest<GetListResponse<GetListMaterialCopyListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialCopies({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialCopies";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialCopyQueryHandler : IRequestHandler<GetListMaterialCopyQuery, GetListResponse<GetListMaterialCopyListItemDto>>
    {
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly IMapper _mapper;

        public GetListMaterialCopyQueryHandler(IMaterialCopyRepository materialCopyRepository, IMapper mapper)
        {
            _materialCopyRepository = materialCopyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialCopyListItemDto>> Handle(GetListMaterialCopyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialCopy> materialCopies = await _materialCopyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialCopyListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialCopyListItemDto>>(materialCopies);
            return response;
        }
    }
}