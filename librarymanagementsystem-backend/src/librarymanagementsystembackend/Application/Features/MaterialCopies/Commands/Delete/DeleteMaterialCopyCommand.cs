using Application.Features.MaterialCopies.Constants;
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

namespace Application.Features.MaterialCopies.Commands.Delete;

public class DeleteMaterialCopyCommand : IRequest<DeletedMaterialCopyResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialCopiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialCopies"];

    public class DeleteMaterialCopyCommandHandler : IRequestHandler<DeleteMaterialCopyCommand, DeletedMaterialCopyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;

        public DeleteMaterialCopyCommandHandler(IMapper mapper, IMaterialCopyRepository materialCopyRepository,
                                         MaterialCopyBusinessRules materialCopyBusinessRules)
        {
            _mapper = mapper;
            _materialCopyRepository = materialCopyRepository;
            _materialCopyBusinessRules = materialCopyBusinessRules;
        }

        public async Task<DeletedMaterialCopyResponse> Handle(DeleteMaterialCopyCommand request, CancellationToken cancellationToken)
        {
            MaterialCopy? materialCopy = await _materialCopyRepository.GetAsync(predicate: mc => mc.Id == request.Id, cancellationToken: cancellationToken);
            await _materialCopyBusinessRules.MaterialCopyShouldExistWhenSelected(materialCopy);

            await _materialCopyRepository.DeleteAsync(materialCopy!);

            DeletedMaterialCopyResponse response = _mapper.Map<DeletedMaterialCopyResponse>(materialCopy);
            return response;
        }
    }
}