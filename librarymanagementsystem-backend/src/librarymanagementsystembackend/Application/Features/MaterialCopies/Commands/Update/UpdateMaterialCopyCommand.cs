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

namespace Application.Features.MaterialCopies.Commands.Update;

public class UpdateMaterialCopyCommand : IRequest<UpdatedMaterialCopyResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public Guid Id { get; set; }
    public DateTime DateReceipt { get; set; }
    public string Status { get; set; }
    public bool IsReserved { get; set; }
    public bool IsReservable { get; set; }
    public Guid MaterialId { get; set; }
    public Guid BranchId { get; set; }
    public Guid? LocationId { get; set; }

    public string[] Roles => [Admin, Write, MaterialCopiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialCopies"];

    public class UpdateMaterialCopyCommandHandler : IRequestHandler<UpdateMaterialCopyCommand, UpdatedMaterialCopyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;

        public UpdateMaterialCopyCommandHandler(IMapper mapper, IMaterialCopyRepository materialCopyRepository,
                                         MaterialCopyBusinessRules materialCopyBusinessRules)
        {
            _mapper = mapper;
            _materialCopyRepository = materialCopyRepository;
            _materialCopyBusinessRules = materialCopyBusinessRules;
        }

        public async Task<UpdatedMaterialCopyResponse> Handle(UpdateMaterialCopyCommand request, CancellationToken cancellationToken)
        {
            MaterialCopy? materialCopy = await _materialCopyRepository.GetAsync(predicate: mc => mc.Id == request.Id, cancellationToken: cancellationToken);
            await _materialCopyBusinessRules.MaterialCopyShouldExistWhenSelected(materialCopy);
            materialCopy = _mapper.Map(request, materialCopy);

            await _materialCopyRepository.UpdateAsync(materialCopy!);

            UpdatedMaterialCopyResponse response = _mapper.Map<UpdatedMaterialCopyResponse>(materialCopy);
            return response;
        }
    }
}