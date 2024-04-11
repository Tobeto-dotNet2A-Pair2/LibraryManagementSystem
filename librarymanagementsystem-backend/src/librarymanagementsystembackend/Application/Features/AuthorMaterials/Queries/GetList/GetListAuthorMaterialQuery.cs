using Application.Features.AuthorMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AuthorMaterials.Constants.AuthorMaterialsOperationClaims;

namespace Application.Features.AuthorMaterials.Queries.GetList;

public class GetListAuthorMaterialQuery : IRequest<GetListResponse<GetListAuthorMaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAuthorMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAuthorMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAuthorMaterialQueryHandler : IRequestHandler<GetListAuthorMaterialQuery, GetListResponse<GetListAuthorMaterialListItemDto>>
    {
        private readonly IAuthorMaterialRepository _authorMaterialRepository;
        private readonly IMapper _mapper;

        public GetListAuthorMaterialQueryHandler(IAuthorMaterialRepository authorMaterialRepository, IMapper mapper)
        {
            _authorMaterialRepository = authorMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorMaterialListItemDto>> Handle(GetListAuthorMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorMaterial> authorMaterials = await _authorMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorMaterialListItemDto>>(authorMaterials);
            return response;
        }
    }
}