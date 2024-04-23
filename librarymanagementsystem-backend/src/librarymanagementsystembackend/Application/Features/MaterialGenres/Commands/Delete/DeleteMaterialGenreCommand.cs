using Application.Features.MaterialGenres.Constants;
using Application.Features.MaterialGenres.Constants;
using Application.Features.MaterialGenres.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialGenres.Constants.MaterialGenresOperationClaims;

namespace Application.Features.MaterialGenres.Commands.Delete;

public class DeleteMaterialGenreCommand : IRequest<DeletedMaterialGenreResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialGenresOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialGenres"];

    public class DeleteMaterialGenreCommandHandler : IRequestHandler<DeleteMaterialGenreCommand, DeletedMaterialGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialGenreRepository _materialGenreRepository;
        private readonly MaterialGenreBusinessRules _materialGenreBusinessRules;

        public DeleteMaterialGenreCommandHandler(IMapper mapper, IMaterialGenreRepository materialGenreRepository,
                                         MaterialGenreBusinessRules materialGenreBusinessRules)
        {
            _mapper = mapper;
            _materialGenreRepository = materialGenreRepository;
            _materialGenreBusinessRules = materialGenreBusinessRules;
        }

        public async Task<DeletedMaterialGenreResponse> Handle(DeleteMaterialGenreCommand request, CancellationToken cancellationToken)
        {
            MaterialGenre? materialGenre = await _materialGenreRepository.GetAsync(predicate: mg => mg.Id == request.Id, cancellationToken: cancellationToken);
            await _materialGenreBusinessRules.MaterialGenreShouldExistWhenSelected(materialGenre);

            await _materialGenreRepository.DeleteAsync(materialGenre!);

            DeletedMaterialGenreResponse response = _mapper.Map<DeletedMaterialGenreResponse>(materialGenre);
            return response;
        }
    }
}