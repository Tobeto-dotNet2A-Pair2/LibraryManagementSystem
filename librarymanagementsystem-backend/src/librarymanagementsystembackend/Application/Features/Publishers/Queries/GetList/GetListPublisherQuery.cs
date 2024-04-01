using Application.Features.Publishers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Publishers.Constants.PublishersOperationClaims;

namespace Application.Features.Publishers.Queries.GetList;

public class GetListPublisherQuery : IRequest<GetListResponse<GetListPublisherListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPublishers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPublishers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPublisherQueryHandler : IRequestHandler<GetListPublisherQuery, GetListResponse<GetListPublisherListItemDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetListPublisherQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPublisherListItemDto>> Handle(GetListPublisherQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Publisher> publishers = await _publisherRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPublisherListItemDto> response = _mapper.Map<GetListResponse<GetListPublisherListItemDto>>(publishers);
            return response;
        }
    }
}