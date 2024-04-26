using Application.Features.Branches.Constants;
using Application.Features.Branches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Branches.Constants.BranchesOperationClaims;

namespace Application.Features.Branches.Queries.GetById;

public class GetByIdBranchQuery : IRequest<GetByIdBranchResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBranchQueryHandler : IRequestHandler<GetByIdBranchQuery, GetByIdBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchBusinessRules _branchBusinessRules;

        public GetByIdBranchQueryHandler(IMapper mapper, IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _branchBusinessRules = branchBusinessRules;
        }

        public async Task<GetByIdBranchResponse> Handle(GetByIdBranchQuery request, CancellationToken cancellationToken)
        {
            Branch? branch = await _branchRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _branchBusinessRules.BranchShouldExistWhenSelected(branch);

            GetByIdBranchResponse response = _mapper.Map<GetByIdBranchResponse>(branch);
            return response;
        }
    }
}