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

namespace Application.Features.MaterialGenres.Commands.Create;

public class CreateMaterialGenreCommand : IRequest<CreatedMaterialGenreResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid GenreId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialGenresOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialGenres"];

    public class CreateMaterialGenreCommandHandler : IRequestHandler<CreateMaterialGenreCommand, CreatedMaterialGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialGenreRepository _materialGenreRepository;
        private readonly MaterialGenreBusinessRules _materialGenreBusinessRules;

        public CreateMaterialGenreCommandHandler(IMapper mapper, IMaterialGenreRepository materialGenreRepository,
                                         MaterialGenreBusinessRules materialGenreBusinessRules)
        {
            _mapper = mapper;
            _materialGenreRepository = materialGenreRepository;
            _materialGenreBusinessRules = materialGenreBusinessRules;
        }

        public async Task<CreatedMaterialGenreResponse> Handle(CreateMaterialGenreCommand request, CancellationToken cancellationToken)
        {
            MaterialGenre materialGenre = _mapper.Map<MaterialGenre>(request);

            await _materialGenreRepository.AddAsync(materialGenre);

            CreatedMaterialGenreResponse response = _mapper.Map<CreatedMaterialGenreResponse>(materialGenre);
            return response;
        }
    }
}