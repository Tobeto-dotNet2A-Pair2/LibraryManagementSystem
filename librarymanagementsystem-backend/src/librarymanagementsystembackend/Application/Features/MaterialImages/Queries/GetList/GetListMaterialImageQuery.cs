using Application.Features.MaterialImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialImages.Constants.MaterialImagesOperationClaims;

namespace Application.Features.MaterialImages.Queries.GetList;

public class GetListMaterialImageQuery : IRequest<GetListResponse<GetListMaterialImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialImageQueryHandler : IRequestHandler<GetListMaterialImageQuery, GetListResponse<GetListMaterialImageListItemDto>>
    {
        private readonly IMaterialImageRepository _materialImageRepository;
        private readonly IMapper _mapper;

        public GetListMaterialImageQueryHandler(IMaterialImageRepository materialImageRepository, IMapper mapper)
        {
            _materialImageRepository = materialImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialImageListItemDto>> Handle(GetListMaterialImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialImage> materialImages = await _materialImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialImageListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialImageListItemDto>>(materialImages);
            return response;
        }
    }
}