using Application.Features.MaterialProperties.Constants;
using Application.Features.MaterialProperties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialProperties.Constants.MaterialPropertiesOperationClaims;

namespace Application.Features.MaterialProperties.Queries.GetById;

public class GetByIdMaterialPropertyQuery : IRequest<GetByIdMaterialPropertyResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialPropertyQueryHandler : IRequestHandler<GetByIdMaterialPropertyQuery, GetByIdMaterialPropertyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly MaterialPropertyBusinessRules _materialPropertyBusinessRules;

        public GetByIdMaterialPropertyQueryHandler(IMapper mapper, IMaterialPropertyRepository materialPropertyRepository, MaterialPropertyBusinessRules materialPropertyBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyRepository = materialPropertyRepository;
            _materialPropertyBusinessRules = materialPropertyBusinessRules;
        }

        public async Task<GetByIdMaterialPropertyResponse> Handle(GetByIdMaterialPropertyQuery request, CancellationToken cancellationToken)
        {
            MaterialProperty? materialProperty = await _materialPropertyRepository.GetAsync(predicate: mp => mp.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPropertyBusinessRules.MaterialPropertyShouldExistWhenSelected(materialProperty);

            GetByIdMaterialPropertyResponse response = _mapper.Map<GetByIdMaterialPropertyResponse>(materialProperty);
            return response;
        }
    }
}