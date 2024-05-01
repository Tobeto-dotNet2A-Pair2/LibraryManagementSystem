using Application.Features.MaterialImages.Constants;
using Application.Features.MaterialImages.Constants;
using Application.Features.MaterialImages.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialImages.Constants.MaterialImagesOperationClaims;

namespace Application.Features.MaterialImages.Commands.Delete;

public class DeleteMaterialImageCommand : IRequest<DeletedMaterialImageResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialImagesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialImages"];

    public class DeleteMaterialImageCommandHandler : IRequestHandler<DeleteMaterialImageCommand, DeletedMaterialImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialImageRepository _materialImageRepository;
        private readonly MaterialImageBusinessRules _materialImageBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public DeleteMaterialImageCommandHandler(IMapper mapper, IMaterialImageRepository materialImageRepository,
                                         MaterialImageBusinessRules materialImageBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _materialImageRepository = materialImageRepository;
            _materialImageBusinessRules = materialImageBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<DeletedMaterialImageResponse> Handle(DeleteMaterialImageCommand request, CancellationToken cancellationToken)
        {
            MaterialImage? materialImage = await _materialImageRepository.GetAsync(predicate: mi => mi.Id == request.Id, cancellationToken: cancellationToken);
            await _materialImageBusinessRules.MaterialImageShouldExistWhenSelected(materialImage);

            materialImage!.DeletedDate = DateTime.UtcNow;
            await _materialImageRepository.UpdateAsync(materialImage!);

            await _imageServiceBase.DeleteAsync(materialImage!.Url);

            DeletedMaterialImageResponse response = _mapper.Map<DeletedMaterialImageResponse>(materialImage);
            return response;
        }
    }
}