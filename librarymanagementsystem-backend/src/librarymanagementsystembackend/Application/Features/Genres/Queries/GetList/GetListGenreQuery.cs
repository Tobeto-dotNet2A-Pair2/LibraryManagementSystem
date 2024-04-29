using Application.Features.Genres.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Genres.Constants.GenresOperationClaims;

namespace Application.Features.Genres.Queries.GetList;

public class GetListGenreQuery : IRequest<GetListResponse<GetListGenreListItemDto>>, ICachableRequest // ISecuredRequest,
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListGenres({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetGenres";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListGenreQueryHandler : IRequestHandler<GetListGenreQuery, GetListResponse<GetListGenreListItemDto>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetListGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGenreListItemDto>> Handle(GetListGenreQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Genre> genres = await _genreRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGenreListItemDto> response = _mapper.Map<GetListResponse<GetListGenreListItemDto>>(genres);
            return response;
        }
    }
}