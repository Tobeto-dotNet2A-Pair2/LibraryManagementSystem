using Application.Features.BorrowMaterials.Constants;
using Application.Features.BorrowMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BorrowMaterials.Constants.BorrowMaterialsOperationClaims;

namespace Application.Features.BorrowMaterials.Commands.Create;

public class CreateBorrowMaterialCommand : IRequest<CreatedBorrowMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Guid MemberId { get; set; }

    public string[] Roles => [Admin, Write, BorrowMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBorrowMaterials"];

    public class CreateBorrowMaterialCommandHandler : IRequestHandler<CreateBorrowMaterialCommand, CreatedBorrowMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowMaterialRepository _borrowMaterialRepository;
        private readonly BorrowMaterialBusinessRules _borrowMaterialBusinessRules;

        public CreateBorrowMaterialCommandHandler(IMapper mapper, IBorrowMaterialRepository borrowMaterialRepository,
                                         BorrowMaterialBusinessRules borrowMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowMaterialRepository = borrowMaterialRepository;
            _borrowMaterialBusinessRules = borrowMaterialBusinessRules;
        }

        public async Task<CreatedBorrowMaterialResponse> Handle(CreateBorrowMaterialCommand request, CancellationToken cancellationToken)
        {
            BorrowMaterial borrowMaterial = _mapper.Map<BorrowMaterial>(request);

            await _borrowMaterialRepository.AddAsync(borrowMaterial);

            CreatedBorrowMaterialResponse response = _mapper.Map<CreatedBorrowMaterialResponse>(borrowMaterial);
            return response;
        }
    }
}