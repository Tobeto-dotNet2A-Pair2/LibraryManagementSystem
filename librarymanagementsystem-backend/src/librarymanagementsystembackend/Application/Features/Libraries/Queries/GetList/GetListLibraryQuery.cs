using Application.Features.Libraries.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Libraries.Constants.LibrariesOperationClaims;

namespace Application.Features.Libraries.Queries.GetList;

public class GetListLibraryQuery : IRequest<GetListResponse<GetListLibraryListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListLibraries({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetLibraries";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLibraryQueryHandler : IRequestHandler<GetListLibraryQuery, GetListResponse<GetListLibraryListItemDto>>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetListLibraryQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLibraryListItemDto>> Handle(GetListLibraryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Library> libraries = await _libraryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLibraryListItemDto> response = _mapper.Map<GetListResponse<GetListLibraryListItemDto>>(libraries);
            return response;
        }
    }
}