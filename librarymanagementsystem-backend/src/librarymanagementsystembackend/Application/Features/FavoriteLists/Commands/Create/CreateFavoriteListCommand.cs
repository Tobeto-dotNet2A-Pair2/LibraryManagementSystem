using Application.Features.FavoriteLists.Constants;
using Application.Features.FavoriteLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FavoriteLists.Constants.FavoriteListsOperationClaims;

namespace Application.Features.FavoriteLists.Commands.Create;

public class CreateFavoriteListCommand : IRequest<CreatedFavoriteListResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public string Name { get; set; }
    public Guid MemberId { get; set; }

    public string[] Roles => [Admin, Write, FavoriteListsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFavoriteLists"];

    public class CreateFavoriteListCommandHandler : IRequestHandler<CreateFavoriteListCommand, CreatedFavoriteListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListRepository _favoriteListRepository;
        private readonly FavoriteListBusinessRules _favoriteListBusinessRules;

        public CreateFavoriteListCommandHandler(IMapper mapper, IFavoriteListRepository favoriteListRepository,
                                         FavoriteListBusinessRules favoriteListBusinessRules)
        {
            _mapper = mapper;
            _favoriteListRepository = favoriteListRepository;
            _favoriteListBusinessRules = favoriteListBusinessRules;
        }

        public async Task<CreatedFavoriteListResponse> Handle(CreateFavoriteListCommand request, CancellationToken cancellationToken)
        {
            FavoriteList favoriteList = _mapper.Map<FavoriteList>(request);

            await _favoriteListRepository.AddAsync(favoriteList);

            CreatedFavoriteListResponse response = _mapper.Map<CreatedFavoriteListResponse>(favoriteList);
            return response;
        }
    }
}