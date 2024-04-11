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

namespace Application.Features.AuthorMaterials.Commands.Update;

public class UpdateAuthorMaterialCommand : IRequest<UpdatedAuthorMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, AuthorMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAuthorMaterials"];

    public class UpdateAuthorMaterialCommandHandler : IRequestHandler<UpdateAuthorMaterialCommand, UpdatedAuthorMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorMaterialRepository _authorMaterialRepository;
        private readonly AuthorMaterialBusinessRules _authorMaterialBusinessRules;

        public UpdateAuthorMaterialCommandHandler(IMapper mapper, IAuthorMaterialRepository authorMaterialRepository,
                                         AuthorMaterialBusinessRules authorMaterialBusinessRules)
        {
            _mapper = mapper;
            _authorMaterialRepository = authorMaterialRepository;
            _authorMaterialBusinessRules = authorMaterialBusinessRules;
        }

        public async Task<UpdatedAuthorMaterialResponse> Handle(UpdateAuthorMaterialCommand request, CancellationToken cancellationToken)
        {
            AuthorMaterial? authorMaterial = await _authorMaterialRepository.GetAsync(predicate: am => am.Id == request.Id, cancellationToken: cancellationToken);
            await _authorMaterialBusinessRules.AuthorMaterialShouldExistWhenSelected(authorMaterial);
            authorMaterial = _mapper.Map(request, authorMaterial);

            await _authorMaterialRepository.UpdateAsync(authorMaterial!);

            UpdatedAuthorMaterialResponse response = _mapper.Map<UpdatedAuthorMaterialResponse>(authorMaterial);
            return response;
        }
    }
}