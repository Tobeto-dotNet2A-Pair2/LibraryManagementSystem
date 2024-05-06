using Application.Features.Branches.Constants;
using Application.Features.Branches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Branches.Constants.BranchesOperationClaims;

namespace Application.Features.Branches.Commands.Update;

public class UpdateBranchCommand : IRequest<UpdatedBranchResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest,ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime WorkingHours { get; set; }
    public string PhoneNumber { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }

    public string[] Roles => [Admin, Write, BranchesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBranches"];

    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, UpdatedBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchBusinessRules _branchBusinessRules;

        public UpdateBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository,
                                         BranchBusinessRules branchBusinessRules)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _branchBusinessRules = branchBusinessRules;
        }

        public async Task<UpdatedBranchResponse> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            Branch? branch = await _branchRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _branchBusinessRules.BranchShouldExistWhenSelected(branch);
            branch = _mapper.Map(request, branch);

            await _branchRepository.UpdateAsync(branch!);

            UpdatedBranchResponse response = _mapper.Map<UpdatedBranchResponse>(branch);
            return response;
        }
    }
}