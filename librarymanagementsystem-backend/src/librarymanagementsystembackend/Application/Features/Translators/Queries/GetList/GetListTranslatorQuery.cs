using Application.Features.Translators.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Translators.Constants.TranslatorsOperationClaims;

namespace Application.Features.Translators.Queries.GetList;

public class GetListTranslatorQuery : IRequest<GetListResponse<GetListTranslatorListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTranslators({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTranslators";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTranslatorQueryHandler : IRequestHandler<GetListTranslatorQuery, GetListResponse<GetListTranslatorListItemDto>>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public GetListTranslatorQueryHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTranslatorListItemDto>> Handle(GetListTranslatorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Translator> translators = await _translatorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTranslatorListItemDto> response = _mapper.Map<GetListResponse<GetListTranslatorListItemDto>>(translators);
            return response;
        }
    }
}