using Application.Features.Genres.Constants;
using Application.Features.Genres.Constants;
using Application.Features.Genres.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Genres.Constants.GenresOperationClaims;

namespace Application.Features.Genres.Commands.Delete;

public class DeleteGenreCommand : IRequest<DeletedGenreResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, GenresOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetGenres"];

    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, DeletedGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;
        private readonly GenreBusinessRules _genreBusinessRules;

        public DeleteGenreCommandHandler(IMapper mapper, IGenreRepository genreRepository,
                                         GenreBusinessRules genreBusinessRules)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<DeletedGenreResponse> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            Genre? genre = await _genreRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _genreBusinessRules.GenreShouldExistWhenSelected(genre);

            await _genreRepository.DeleteAsync(genre!);

            DeletedGenreResponse response = _mapper.Map<DeletedGenreResponse>(genre);
            return response;
        }
    }
}