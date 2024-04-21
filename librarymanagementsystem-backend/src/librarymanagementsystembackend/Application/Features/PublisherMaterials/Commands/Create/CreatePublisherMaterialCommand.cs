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

namespace Application.Features.PublisherMaterials.Commands.Create;

public class CreatePublisherMaterialCommand : IRequest<CreatedPublisherMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid PublisherId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, PublisherMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPublisherMaterials"];

    public class CreatePublisherMaterialCommandHandler : IRequestHandler<CreatePublisherMaterialCommand, CreatedPublisherMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPublisherMaterialRepository _publisherMaterialRepository;
        private readonly PublisherMaterialBusinessRules _publisherMaterialBusinessRules;

        public CreatePublisherMaterialCommandHandler(IMapper mapper, IPublisherMaterialRepository publisherMaterialRepository,
                                         PublisherMaterialBusinessRules publisherMaterialBusinessRules)
        {
            _mapper = mapper;
            _publisherMaterialRepository = publisherMaterialRepository;
            _publisherMaterialBusinessRules = publisherMaterialBusinessRules;
        }

        public async Task<CreatedPublisherMaterialResponse> Handle(CreatePublisherMaterialCommand request, CancellationToken cancellationToken)
        {
            PublisherMaterial publisherMaterial = _mapper.Map<PublisherMaterial>(request);

            await _publisherMaterialRepository.AddAsync(publisherMaterial);

            CreatedPublisherMaterialResponse response = _mapper.Map<CreatedPublisherMaterialResponse>(publisherMaterial);
            return response;
        }
    }
}