using Application.Features.PublisherMaterials.Constants;
using Application.Features.PublisherMaterials.Constants;
using Application.Features.PublisherMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PublisherMaterials.Constants.PublisherMaterialsOperationClaims;

namespace Application.Features.PublisherMaterials.Commands.Delete;

public class DeletePublisherMaterialCommand : IRequest<DeletedPublisherMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PublisherMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPublisherMaterials"];

    public class DeletePublisherMaterialCommandHandler : IRequestHandler<DeletePublisherMaterialCommand, DeletedPublisherMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPublisherMaterialRepository _publisherMaterialRepository;
        private readonly PublisherMaterialBusinessRules _publisherMaterialBusinessRules;

        public DeletePublisherMaterialCommandHandler(IMapper mapper, IPublisherMaterialRepository publisherMaterialRepository,
                                         PublisherMaterialBusinessRules publisherMaterialBusinessRules)
        {
            _mapper = mapper;
            _publisherMaterialRepository = publisherMaterialRepository;
            _publisherMaterialBusinessRules = publisherMaterialBusinessRules;
        }

        public async Task<DeletedPublisherMaterialResponse> Handle(DeletePublisherMaterialCommand request, CancellationToken cancellationToken)
        {
            PublisherMaterial? publisherMaterial = await _publisherMaterialRepository.GetAsync(predicate: pm => pm.Id == request.Id, cancellationToken: cancellationToken);
            await _publisherMaterialBusinessRules.PublisherMaterialShouldExistWhenSelected(publisherMaterial);

            await _publisherMaterialRepository.DeleteAsync(publisherMaterial!);

            DeletedPublisherMaterialResponse response = _mapper.Map<DeletedPublisherMaterialResponse>(publisherMaterial);
            return response;
        }
    }
}