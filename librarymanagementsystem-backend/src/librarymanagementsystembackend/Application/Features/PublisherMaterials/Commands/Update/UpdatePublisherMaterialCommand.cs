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

namespace Application.Features.PublisherMaterials.Commands.Update;

public class UpdatePublisherMaterialCommand : IRequest<UpdatedPublisherMaterialResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid PublisherId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, PublisherMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPublisherMaterials"];

    public class UpdatePublisherMaterialCommandHandler : IRequestHandler<UpdatePublisherMaterialCommand, UpdatedPublisherMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPublisherMaterialRepository _publisherMaterialRepository;
        private readonly PublisherMaterialBusinessRules _publisherMaterialBusinessRules;

        public UpdatePublisherMaterialCommandHandler(IMapper mapper, IPublisherMaterialRepository publisherMaterialRepository,
                                         PublisherMaterialBusinessRules publisherMaterialBusinessRules)
        {
            _mapper = mapper;
            _publisherMaterialRepository = publisherMaterialRepository;
            _publisherMaterialBusinessRules = publisherMaterialBusinessRules;
        }

        public async Task<UpdatedPublisherMaterialResponse> Handle(UpdatePublisherMaterialCommand request, CancellationToken cancellationToken)
        {
            PublisherMaterial? publisherMaterial = await _publisherMaterialRepository.GetAsync(predicate: pm => pm.Id == request.Id, cancellationToken: cancellationToken);
            await _publisherMaterialBusinessRules.PublisherMaterialShouldExistWhenSelected(publisherMaterial);
            publisherMaterial = _mapper.Map(request, publisherMaterial);

            await _publisherMaterialRepository.UpdateAsync(publisherMaterial!);

            UpdatedPublisherMaterialResponse response = _mapper.Map<UpdatedPublisherMaterialResponse>(publisherMaterial);
            return response;
        }
    }
}