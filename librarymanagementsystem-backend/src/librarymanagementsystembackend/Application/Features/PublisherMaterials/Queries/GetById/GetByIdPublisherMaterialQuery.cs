using Application.Features.PublisherMaterials.Constants;
using Application.Features.PublisherMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PublisherMaterials.Constants.PublisherMaterialsOperationClaims;

namespace Application.Features.PublisherMaterials.Queries.GetById;

public class GetByIdPublisherMaterialQuery : IRequest<GetByIdPublisherMaterialResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPublisherMaterialQueryHandler : IRequestHandler<GetByIdPublisherMaterialQuery, GetByIdPublisherMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPublisherMaterialRepository _publisherMaterialRepository;
        private readonly PublisherMaterialBusinessRules _publisherMaterialBusinessRules;

        public GetByIdPublisherMaterialQueryHandler(IMapper mapper, IPublisherMaterialRepository publisherMaterialRepository, PublisherMaterialBusinessRules publisherMaterialBusinessRules)
        {
            _mapper = mapper;
            _publisherMaterialRepository = publisherMaterialRepository;
            _publisherMaterialBusinessRules = publisherMaterialBusinessRules;
        }

        public async Task<GetByIdPublisherMaterialResponse> Handle(GetByIdPublisherMaterialQuery request, CancellationToken cancellationToken)
        {
            PublisherMaterial? publisherMaterial = await _publisherMaterialRepository.GetAsync(predicate: pm => pm.Id == request.Id, cancellationToken: cancellationToken);
            await _publisherMaterialBusinessRules.PublisherMaterialShouldExistWhenSelected(publisherMaterial);

            GetByIdPublisherMaterialResponse response = _mapper.Map<GetByIdPublisherMaterialResponse>(publisherMaterial);
            return response;
        }
    }
}