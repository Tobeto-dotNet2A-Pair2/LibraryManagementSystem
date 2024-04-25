using Application.Features.MaterialImages.Constants;
using Application.Features.MaterialImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialImages.Constants.MaterialImagesOperationClaims;

namespace Application.Features.MaterialImages.Commands.Create;

public class CreateMaterialImageCommand : IRequest<CreatedMaterialImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Url { get; set; }
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

        public CreateMaterialImageCommandHandler(IMapper mapper, IMaterialImageRepository materialImageRepository,
                                         MaterialImageBusinessRules materialImageBusinessRules)
        {
            _mapper = mapper;
            _materialImageRepository = materialImageRepository;
            _materialImageBusinessRules = materialImageBusinessRules;
        }

        public async Task<CreatedMaterialImageResponse> Handle(CreateMaterialImageCommand request, CancellationToken cancellationToken)
        {
            MaterialImage materialImage = _mapper.Map<MaterialImage>(request);

            await _materialImageRepository.AddAsync(materialImage);

            CreatedMaterialImageResponse response = _mapper.Map<CreatedMaterialImageResponse>(materialImage);
            return response;
        }
    }
}