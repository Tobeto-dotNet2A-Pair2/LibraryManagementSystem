using Application.Features.Genres.Constants;
using Application.Features.Genres.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Genres.Constants.GenresOperationClaims;

namespace Application.Features.Genres.Queries.GetById;

public class GetByIdGenreQuery : IRequest<GetByIdGenreResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQuery, GetByIdGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;
        private readonly GenreBusinessRules _genreBusinessRules;

        public GetByIdGenreQueryHandler(IMapper mapper, IGenreRepository genreRepository, GenreBusinessRules genreBusinessRules)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<GetByIdGenreResponse> Handle(GetByIdGenreQuery request, CancellationToken cancellationToken)
        {
            Genre? genre = await _genreRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _genreBusinessRules.GenreShouldExistWhenSelected(genre);

            GetByIdGenreResponse response = _mapper.Map<GetByIdGenreResponse>(genre);
            return response;
        }
    }
}