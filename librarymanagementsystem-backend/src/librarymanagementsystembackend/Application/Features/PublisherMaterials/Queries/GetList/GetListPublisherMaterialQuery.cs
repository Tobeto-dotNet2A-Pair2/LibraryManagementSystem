using Application.Features.PublisherMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PublisherMaterials.Constants.PublisherMaterialsOperationClaims;

namespace Application.Features.PublisherMaterials.Queries.GetList;

public class GetListPublisherMaterialQuery : IRequest<GetListResponse<GetListPublisherMaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPublisherMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPublisherMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPublisherMaterialQueryHandler : IRequestHandler<GetListPublisherMaterialQuery, GetListResponse<GetListPublisherMaterialListItemDto>>
    {
        private readonly IPublisherMaterialRepository _publisherMaterialRepository;
        private readonly IMapper _mapper;

        public GetListPublisherMaterialQueryHandler(IPublisherMaterialRepository publisherMaterialRepository, IMapper mapper)
        {
            _publisherMaterialRepository = publisherMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPublisherMaterialListItemDto>> Handle(GetListPublisherMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PublisherMaterial> publisherMaterials = await _publisherMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPublisherMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListPublisherMaterialListItemDto>>(publisherMaterials);
            return response;
        }
    }
}