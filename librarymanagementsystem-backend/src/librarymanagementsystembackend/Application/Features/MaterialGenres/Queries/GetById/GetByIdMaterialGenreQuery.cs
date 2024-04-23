using Application.Features.MaterialGenres.Constants;
using Application.Features.MaterialGenres.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialGenres.Constants.MaterialGenresOperationClaims;

namespace Application.Features.MaterialGenres.Queries.GetById;

public class GetByIdMaterialGenreQuery : IRequest<GetByIdMaterialGenreResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialGenreQueryHandler : IRequestHandler<GetByIdMaterialGenreQuery, GetByIdMaterialGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialGenreRepository _materialGenreRepository;
        private readonly MaterialGenreBusinessRules _materialGenreBusinessRules;

        public GetByIdMaterialGenreQueryHandler(IMapper mapper, IMaterialGenreRepository materialGenreRepository, MaterialGenreBusinessRules materialGenreBusinessRules)
        {
            _mapper = mapper;
            _materialGenreRepository = materialGenreRepository;
            _materialGenreBusinessRules = materialGenreBusinessRules;
        }

        public async Task<GetByIdMaterialGenreResponse> Handle(GetByIdMaterialGenreQuery request, CancellationToken cancellationToken)
        {
            MaterialGenre? materialGenre = await _materialGenreRepository.GetAsync(predicate: mg => mg.Id == request.Id, cancellationToken: cancellationToken);
            await _materialGenreBusinessRules.MaterialGenreShouldExistWhenSelected(materialGenre);

            GetByIdMaterialGenreResponse response = _mapper.Map<GetByIdMaterialGenreResponse>(materialGenre);
            return response;
        }
    }
}