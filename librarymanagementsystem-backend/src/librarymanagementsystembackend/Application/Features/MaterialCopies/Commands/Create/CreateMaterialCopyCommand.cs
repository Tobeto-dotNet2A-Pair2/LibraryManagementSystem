using Application.Features.MaterialCopies.Constants;
using Application.Features.MaterialCopies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialCopies.Constants.MaterialCopiesOperationClaims;

namespace Application.Features.MaterialCopies.Commands.Create;

public class CreateMaterialCopyCommand : IRequest<CreatedMaterialCopyResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public DateTime DateReceipt { get; set; }
    public string Status { get; set; }
    public bool IsReserved { get; set; }
    public bool IsReservable { get; set; }
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid? LocationId { get; set; }

    public string[] Roles => [Admin, Write, MaterialCopiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialCopies"];

    public class CreateMaterialCopyCommandHandler : IRequestHandler<CreateMaterialCopyCommand, CreatedMaterialCopyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;

        public CreateMaterialCopyCommandHandler(IMapper mapper, IMaterialCopyRepository materialCopyRepository,
                                         MaterialCopyBusinessRules materialCopyBusinessRules)
        {
            _mapper = mapper;
            _materialCopyRepository = materialCopyRepository;
            _materialCopyBusinessRules = materialCopyBusinessRules;
        }

        public async Task<CreatedMaterialCopyResponse> Handle(CreateMaterialCopyCommand request, CancellationToken cancellationToken)
        {
            MaterialCopy materialCopy = _mapper.Map<MaterialCopy>(request);

            await _materialCopyRepository.AddAsync(materialCopy);

            CreatedMaterialCopyResponse response = _mapper.Map<CreatedMaterialCopyResponse>(materialCopy);
            return response;
        }
    }
}