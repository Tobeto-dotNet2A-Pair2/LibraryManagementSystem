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

namespace Application.Features.FavoriteLists.Commands.Update;

public class UpdateFavoriteListCommand : IRequest<UpdatedFavoriteListResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MemberId { get; set; }

    public string[] Roles => [Admin, Write, FavoriteListsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFavoriteLists"];

    public class UpdateFavoriteListCommandHandler : IRequestHandler<UpdateFavoriteListCommand, UpdatedFavoriteListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListRepository _favoriteListRepository;
        private readonly FavoriteListBusinessRules _favoriteListBusinessRules;

        public UpdateFavoriteListCommandHandler(IMapper mapper, IFavoriteListRepository favoriteListRepository,
                                         FavoriteListBusinessRules favoriteListBusinessRules)
        {
            _mapper = mapper;
            _favoriteListRepository = favoriteListRepository;
            _favoriteListBusinessRules = favoriteListBusinessRules;
        }

        public async Task<UpdatedFavoriteListResponse> Handle(UpdateFavoriteListCommand request, CancellationToken cancellationToken)
        {
            FavoriteList? favoriteList = await _favoriteListRepository.GetAsync(predicate: fl => fl.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteListBusinessRules.FavoriteListShouldExistWhenSelected(favoriteList);
            favoriteList = _mapper.Map(request, favoriteList);

            await _favoriteListRepository.UpdateAsync(favoriteList!);

            UpdatedFavoriteListResponse response = _mapper.Map<UpdatedFavoriteListResponse>(favoriteList);
            return response;
        }
    }
}