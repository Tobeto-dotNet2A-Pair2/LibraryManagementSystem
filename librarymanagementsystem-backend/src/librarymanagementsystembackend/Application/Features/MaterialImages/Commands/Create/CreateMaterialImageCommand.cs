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
using Microsoft.AspNetCore.Http;
using static Application.Features.MaterialImages.Constants.MaterialImagesOperationClaims;

namespace Application.Features.MaterialImages.Commands.Create;

public class CreateMaterialImageCommand : IRequest<CreatedMaterialImageResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public IFormFile Image { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialImagesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialImages"];

    public class CreateMaterialImageCommandHandler : IRequestHandler<CreateMaterialImageCommand, CreatedMaterialImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialImageRepository _materialImageRepository;
        private readonly MaterialImageBusinessRules _materialImageBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public CreateMaterialImageCommandHandler(IMapper mapper, IMaterialImageRepository materialImageRepository,
                                         MaterialImageBusinessRules materialImageBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _materialImageRepository = materialImageRepository;
            _materialImageBusinessRules = materialImageBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedMaterialImageResponse> Handle(CreateMaterialImageCommand request, CancellationToken cancellationToken)
        {
            string url = await _imageServiceBase.UploadAsync(request.Image);


            MaterialImage materialImage = new MaterialImage()
            {
                Url = url,
                MaterialId = request.MaterialId
            };

            await _materialImageRepository.AddAsync(materialImage);

            CreatedMaterialImageResponse response = _mapper.Map<CreatedMaterialImageResponse>(materialImage);
            return response;
        }
    }
}