using Application.Features.MaterialGenres.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialGenres.Constants.MaterialGenresOperationClaims;

namespace Application.Features.MaterialGenres.Queries.GetList;

public class GetListMaterialGenreQuery : IRequest<GetListResponse<GetListMaterialGenreListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialGenres({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialGenres";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialGenreQueryHandler : IRequestHandler<GetListMaterialGenreQuery, GetListResponse<GetListMaterialGenreListItemDto>>
    {
        private readonly IMaterialGenreRepository _materialGenreRepository;
        private readonly IMapper _mapper;

        public GetListMaterialGenreQueryHandler(IMaterialGenreRepository materialGenreRepository, IMapper mapper)
        {
            _materialGenreRepository = materialGenreRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialGenreListItemDto>> Handle(GetListMaterialGenreQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialGenre> materialGenres = await _materialGenreRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialGenreListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialGenreListItemDto>>(materialGenres);
            return response;
        }
    }
}