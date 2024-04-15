using Application.Features.AuthorMaterials.Constants;
using Application.Features.AuthorMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AuthorMaterials.Constants.AuthorMaterialsOperationClaims;

namespace Application.Features.AuthorMaterials.Queries.GetById;

public class GetByIdAuthorMaterialQuery : IRequest<GetByIdAuthorMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAuthorMaterialQueryHandler : IRequestHandler<GetByIdAuthorMaterialQuery, GetByIdAuthorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorMaterialRepository _authorMaterialRepository;
        private readonly AuthorMaterialBusinessRules _authorMaterialBusinessRules;

        public GetByIdAuthorMaterialQueryHandler(IMapper mapper, IAuthorMaterialRepository authorMaterialRepository, AuthorMaterialBusinessRules authorMaterialBusinessRules)
        {
            _mapper = mapper;
            _authorMaterialRepository = authorMaterialRepository;
            _authorMaterialBusinessRules = authorMaterialBusinessRules;
        }

        public async Task<GetByIdAuthorMaterialResponse> Handle(GetByIdAuthorMaterialQuery request, CancellationToken cancellationToken)
        {
            AuthorMaterial? authorMaterial = await _authorMaterialRepository.GetAsync(predicate: am => am.Id == request.Id, cancellationToken: cancellationToken);
            await _authorMaterialBusinessRules.AuthorMaterialShouldExistWhenSelected(authorMaterial);

            GetByIdAuthorMaterialResponse response = _mapper.Map<GetByIdAuthorMaterialResponse>(authorMaterial);
            return response;
        }
    }
}