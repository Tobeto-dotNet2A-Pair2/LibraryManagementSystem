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

namespace Application.Features.Branches.Commands.Create;

public class CreateBranchCommand : IRequest<CreatedBranchResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public CreateBranchCommand()
    {
        PaymentMethods = new List<PaymentMethodDto>();
    }
    public string Name { get; set; }
    public DateTime WorkingHours { get; set; }
    public string PhoneNumber { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }
    
    //Liste
    public List<PaymentMethodDto> PaymentMethods { get; set; }
    // Tekil
    public AddressDto Address { get; set; }

    public string[] Roles => [Admin, Write, BranchesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBranches"];

    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, CreatedBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchBusinessRules _branchBusinessRules;

        public CreateBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository,
                                         BranchBusinessRules branchBusinessRules)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _branchBusinessRules = branchBusinessRules;
        }

        public async Task<CreatedBranchResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            Branch branch = _mapper.Map<Branch>(request);
            
            /// Address mapping
           branch.Address = _mapper.Map<Address>(request.Address);
            
            ///Payment Mapping
            branch.PaymentMethods = _mapper.Map<List<PaymentMethod>>(request.PaymentMethods);

            await _branchRepository.AddAsync(branch);

            CreatedBranchResponse response = _mapper.Map<CreatedBranchResponse>(branch);
            return response;
        }
    }
}