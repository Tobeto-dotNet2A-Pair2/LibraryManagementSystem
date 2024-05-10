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

namespace Application.Features.FavoriteLists.Commands.Delete;

public class DeleteFavoriteListCommand : IRequest<DeletedFavoriteListResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, FavoriteListsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFavoriteLists"];

    public class DeleteFavoriteListCommandHandler : IRequestHandler<DeleteFavoriteListCommand, DeletedFavoriteListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListRepository _favoriteListRepository;
        private readonly FavoriteListBusinessRules _favoriteListBusinessRules;

        public DeleteFavoriteListCommandHandler(IMapper mapper, IFavoriteListRepository favoriteListRepository,
                                         FavoriteListBusinessRules favoriteListBusinessRules)
        {
            _mapper = mapper;
            _favoriteListRepository = favoriteListRepository;
            _favoriteListBusinessRules = favoriteListBusinessRules;
        }

        public async Task<DeletedFavoriteListResponse> Handle(DeleteFavoriteListCommand request, CancellationToken cancellationToken)
        {
            FavoriteList? favoriteList = await _favoriteListRepository.GetAsync(predicate: fl => fl.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteListBusinessRules.FavoriteListShouldExistWhenSelected(favoriteList);

            await _favoriteListRepository.DeleteAsync(favoriteList!);

            DeletedFavoriteListResponse response = _mapper.Map<DeletedFavoriteListResponse>(favoriteList);
            return response;
        }
    }
}