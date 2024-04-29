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

namespace Application.Features.MaterialGenres.Commands.Update;

public class UpdateMaterialGenreCommand : IRequest<UpdatedMaterialGenreResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialGenresOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialGenres"];

    public class UpdateMaterialGenreCommandHandler : IRequestHandler<UpdateMaterialGenreCommand, UpdatedMaterialGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialGenreRepository _materialGenreRepository;
        private readonly MaterialGenreBusinessRules _materialGenreBusinessRules;

        public UpdateMaterialGenreCommandHandler(IMapper mapper, IMaterialGenreRepository materialGenreRepository,
                                         MaterialGenreBusinessRules materialGenreBusinessRules)
        {
            _mapper = mapper;
            _materialGenreRepository = materialGenreRepository;
            _materialGenreBusinessRules = materialGenreBusinessRules;
        }

        public async Task<UpdatedMaterialGenreResponse> Handle(UpdateMaterialGenreCommand request, CancellationToken cancellationToken)
        {
            MaterialGenre? materialGenre = await _materialGenreRepository.GetAsync(predicate: mg => mg.Id == request.Id, cancellationToken: cancellationToken);
            await _materialGenreBusinessRules.MaterialGenreShouldExistWhenSelected(materialGenre);
            materialGenre = _mapper.Map(request, materialGenre);

            await _materialGenreRepository.UpdateAsync(materialGenre!);

            UpdatedMaterialGenreResponse response = _mapper.Map<UpdatedMaterialGenreResponse>(materialGenre);
            return response;
        }
    }
}