using Application.Features.MaterialPropertyValues.Constants;
using Application.Features.MaterialPropertyValues.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialPropertyValues.Constants.MaterialPropertyValuesOperationClaims;

namespace Application.Features.MaterialPropertyValues.Queries.GetById;

public class GetByIdMaterialPropertyValueQuery : IRequest<GetByIdMaterialPropertyValueResponse> //, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialPropertyValueQueryHandler : IRequestHandler<GetByIdMaterialPropertyValueQuery, GetByIdMaterialPropertyValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPropertyValueRepository _materialPropertyValueRepository;
        private readonly MaterialPropertyValueBusinessRules _materialPropertyValueBusinessRules;

        public GetByIdMaterialPropertyValueQueryHandler(IMapper mapper, IMaterialPropertyValueRepository materialPropertyValueRepository, MaterialPropertyValueBusinessRules materialPropertyValueBusinessRules)
        {
            _mapper = mapper;
            _materialPropertyValueRepository = materialPropertyValueRepository;
            _materialPropertyValueBusinessRules = materialPropertyValueBusinessRules;
        }

        public async Task<GetByIdMaterialPropertyValueResponse> Handle(GetByIdMaterialPropertyValueQuery request, CancellationToken cancellationToken)
        {
            MaterialPropertyValue? materialPropertyValue = await _materialPropertyValueRepository.GetAsync(predicate: mpv => mpv.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPropertyValueBusinessRules.MaterialPropertyValueShouldExistWhenSelected(materialPropertyValue);

            GetByIdMaterialPropertyValueResponse response = _mapper.Map<GetByIdMaterialPropertyValueResponse>(materialPropertyValue);
            return response;
        }
    }
}