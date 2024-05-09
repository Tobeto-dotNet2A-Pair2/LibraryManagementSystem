using Application.Features.FavoriteLists.Constants;
using Application.Features.FavoriteLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FavoriteLists.Constants.FavoriteListsOperationClaims;

namespace Application.Features.FavoriteLists.Queries.GetById;

public class GetByIdFavoriteListQuery : IRequest<GetByIdFavoriteListResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFavoriteListQueryHandler : IRequestHandler<GetByIdFavoriteListQuery, GetByIdFavoriteListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteListRepository _favoriteListRepository;
        private readonly FavoriteListBusinessRules _favoriteListBusinessRules;

        public GetByIdFavoriteListQueryHandler(IMapper mapper, IFavoriteListRepository favoriteListRepository, FavoriteListBusinessRules favoriteListBusinessRules)
        {
            _mapper = mapper;
            _favoriteListRepository = favoriteListRepository;
            _favoriteListBusinessRules = favoriteListBusinessRules;
        }

        public async Task<GetByIdFavoriteListResponse> Handle(GetByIdFavoriteListQuery request, CancellationToken cancellationToken)
        {
            FavoriteList? favoriteList = await _favoriteListRepository.GetAsync(predicate: fl => fl.Id == request.Id, cancellationToken: cancellationToken);
            await _favoriteListBusinessRules.FavoriteListShouldExistWhenSelected(favoriteList);

            GetByIdFavoriteListResponse response = _mapper.Map<GetByIdFavoriteListResponse>(favoriteList);
            return response;
        }
    }
}