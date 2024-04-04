using Application.Features.Streets.Constants;
using Application.Features.Streets.Constants;
using Application.Features.Streets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Streets.Constants.StreetsOperationClaims;

namespace Application.Features.Streets.Commands.Delete;

public class DeleteStreetCommand : IRequest<DeletedStreetResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, StreetsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStreets"];

    public class DeleteStreetCommandHandler : IRequestHandler<DeleteStreetCommand, DeletedStreetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;
        private readonly StreetBusinessRules _streetBusinessRules;

        public DeleteStreetCommandHandler(IMapper mapper, IStreetRepository streetRepository,
                                         StreetBusinessRules streetBusinessRules)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
            _streetBusinessRules = streetBusinessRules;
        }

        public async Task<DeletedStreetResponse> Handle(DeleteStreetCommand request, CancellationToken cancellationToken)
        {
            Street? street = await _streetRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _streetBusinessRules.StreetShouldExistWhenSelected(street);

            await _streetRepository.DeleteAsync(street!);

            DeletedStreetResponse response = _mapper.Map<DeletedStreetResponse>(street);
            return response;
        }
    }
}