using Application.Features.AuthorMaterials.Constants;
using Application.Features.AuthorMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AuthorMaterials.Constants.AuthorMaterialsOperationClaims;

namespace Application.Features.AuthorMaterials.Commands.Create;

public class CreateAuthorMaterialCommand : IRequest<CreatedAuthorMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest, 
{
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, AuthorMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAuthorMaterials"];

    public class CreateAuthorMaterialCommandHandler : IRequestHandler<CreateAuthorMaterialCommand, CreatedAuthorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorMaterialRepository _authorMaterialRepository;
        private readonly AuthorMaterialBusinessRules _authorMaterialBusinessRules;

        public CreateAuthorMaterialCommandHandler(IMapper mapper, IAuthorMaterialRepository authorMaterialRepository,
                                         AuthorMaterialBusinessRules authorMaterialBusinessRules)
        {
            _mapper = mapper;
            _authorMaterialRepository = authorMaterialRepository;
            _authorMaterialBusinessRules = authorMaterialBusinessRules;
        }

        public async Task<CreatedAuthorMaterialResponse> Handle(CreateAuthorMaterialCommand request, CancellationToken cancellationToken)
        {
            AuthorMaterial authorMaterial = _mapper.Map<AuthorMaterial>(request);

            await _authorMaterialRepository.AddAsync(authorMaterial);

            CreatedAuthorMaterialResponse response = _mapper.Map<CreatedAuthorMaterialResponse>(authorMaterial);
            return response;
        }
    }
}