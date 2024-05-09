using Application.Features.Publishers.Constants;
using Application.Features.Publishers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Publishers.Constants.PublishersOperationClaims;

namespace Application.Features.Publishers.Queries.GetById;

public class GetByIdPublisherQuery : IRequest<GetByIdPublisherResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPublisherQueryHandler : IRequestHandler<GetByIdPublisherQuery, GetByIdPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;
        private readonly PublisherBusinessRules _publisherBusinessRules;

        public GetByIdPublisherQueryHandler(IMapper mapper, IPublisherRepository publisherRepository, PublisherBusinessRules publisherBusinessRules)
        {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
            _publisherBusinessRules = publisherBusinessRules;
        }

        public async Task<GetByIdPublisherResponse> Handle(GetByIdPublisherQuery request, CancellationToken cancellationToken)
        {
            Publisher? publisher = await _publisherRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _publisherBusinessRules.PublisherShouldExistWhenSelected(publisher);

            GetByIdPublisherResponse response = _mapper.Map<GetByIdPublisherResponse>(publisher);
            return response;
        }
    }
}