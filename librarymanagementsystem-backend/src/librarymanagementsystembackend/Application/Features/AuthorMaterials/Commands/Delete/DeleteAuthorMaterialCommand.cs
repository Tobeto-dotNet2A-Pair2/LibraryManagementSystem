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

namespace Application.Features.AuthorMaterials.Commands.Delete;

public class DeleteAuthorMaterialCommand : IRequest<DeletedAuthorMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AuthorMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAuthorMaterials"];

    public class DeleteAuthorMaterialCommandHandler : IRequestHandler<DeleteAuthorMaterialCommand, DeletedAuthorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorMaterialRepository _authorMaterialRepository;
        private readonly AuthorMaterialBusinessRules _authorMaterialBusinessRules;

        public DeleteAuthorMaterialCommandHandler(IMapper mapper, IAuthorMaterialRepository authorMaterialRepository,
                                         AuthorMaterialBusinessRules authorMaterialBusinessRules)
        {
            _mapper = mapper;
            _authorMaterialRepository = authorMaterialRepository;
            _authorMaterialBusinessRules = authorMaterialBusinessRules;
        }

        public async Task<DeletedAuthorMaterialResponse> Handle(DeleteAuthorMaterialCommand request, CancellationToken cancellationToken)
        {
            AuthorMaterial? authorMaterial = await _authorMaterialRepository.GetAsync(predicate: am => am.Id == request.Id, cancellationToken: cancellationToken);
            await _authorMaterialBusinessRules.AuthorMaterialShouldExistWhenSelected(authorMaterial);

            await _authorMaterialRepository.DeleteAsync(authorMaterial!);

            DeletedAuthorMaterialResponse response = _mapper.Map<DeletedAuthorMaterialResponse>(authorMaterial);
            return response;
        }
    }
}