using Application.Features.MaterialTypes.Constants;
using Application.Features.MaterialTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialTypes.Constants.MaterialTypesOperationClaims;

namespace Application.Features.MaterialTypes.Queries.GetById;

public class GetByIdMaterialTypeQuery : IRequest<GetByIdMaterialTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialTypeQueryHandler : IRequestHandler<GetByIdMaterialTypeQuery, GetByIdMaterialTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly MaterialTypeBusinessRules _materialTypeBusinessRules;

        public GetByIdMaterialTypeQueryHandler(IMapper mapper, IMaterialTypeRepository materialTypeRepository, MaterialTypeBusinessRules materialTypeBusinessRules)
        {
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
            _materialTypeBusinessRules = materialTypeBusinessRules;
        }

        public async Task<GetByIdMaterialTypeResponse> Handle(GetByIdMaterialTypeQuery request, CancellationToken cancellationToken)
        {
            MaterialType? materialType = await _materialTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _materialTypeBusinessRules.MaterialTypeShouldExistWhenSelected(materialType);

            GetByIdMaterialTypeResponse response = _mapper.Map<GetByIdMaterialTypeResponse>(materialType);
            return response;
        }
    }
}