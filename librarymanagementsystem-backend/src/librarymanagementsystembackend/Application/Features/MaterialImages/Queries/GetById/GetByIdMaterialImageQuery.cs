using Application.Features.MaterialImages.Constants;
using Application.Features.MaterialImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialImages.Constants.MaterialImagesOperationClaims;

namespace Application.Features.MaterialImages.Queries.GetById;

public class GetByIdMaterialImageQuery : IRequest<GetByIdMaterialImageResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialImageQueryHandler : IRequestHandler<GetByIdMaterialImageQuery, GetByIdMaterialImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialImageRepository _materialImageRepository;
        private readonly MaterialImageBusinessRules _materialImageBusinessRules;

        public GetByIdMaterialImageQueryHandler(IMapper mapper, IMaterialImageRepository materialImageRepository, MaterialImageBusinessRules materialImageBusinessRules)
        {
            _mapper = mapper;
            _materialImageRepository = materialImageRepository;
            _materialImageBusinessRules = materialImageBusinessRules;
        }

        public async Task<GetByIdMaterialImageResponse> Handle(GetByIdMaterialImageQuery request, CancellationToken cancellationToken)
        {
            MaterialImage? materialImage = await _materialImageRepository.GetAsync(predicate: mi => mi.Id == request.Id, cancellationToken: cancellationToken);
            await _materialImageBusinessRules.MaterialImageShouldExistWhenSelected(materialImage);

            GetByIdMaterialImageResponse response = _mapper.Map<GetByIdMaterialImageResponse>(materialImage);
            return response;
        }
    }
}