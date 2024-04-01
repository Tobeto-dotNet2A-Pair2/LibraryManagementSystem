using Application.Features.Streets.Constants;
using Application.Features.Streets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Streets.Constants.StreetsOperationClaims;

namespace Application.Features.Streets.Queries.GetById;

public class GetByIdStreetQuery : IRequest<GetByIdStreetResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdStreetQueryHandler : IRequestHandler<GetByIdStreetQuery, GetByIdStreetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;
        private readonly StreetBusinessRules _streetBusinessRules;

        public GetByIdStreetQueryHandler(IMapper mapper, IStreetRepository streetRepository, StreetBusinessRules streetBusinessRules)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
            _streetBusinessRules = streetBusinessRules;
        }

        public async Task<GetByIdStreetResponse> Handle(GetByIdStreetQuery request, CancellationToken cancellationToken)
        {
            Street? street = await _streetRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _streetBusinessRules.StreetShouldExistWhenSelected(street);

            GetByIdStreetResponse response = _mapper.Map<GetByIdStreetResponse>(street);
            return response;
        }
    }
}