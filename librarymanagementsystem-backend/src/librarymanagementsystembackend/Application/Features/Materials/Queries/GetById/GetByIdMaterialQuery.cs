using Application.Features.Materials.Constants;
using Application.Features.Materials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Materials.Constants.MaterialsOperationClaims;

namespace Application.Features.Materials.Queries.GetById;

public class GetByIdMaterialQuery : IRequest<GetByIdMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialQueryHandler : IRequestHandler<GetByIdMaterialQuery, GetByIdMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly MaterialBusinessRules _materialBusinessRules;

        public GetByIdMaterialQueryHandler(IMapper mapper, IMaterialRepository materialRepository, MaterialBusinessRules materialBusinessRules)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialBusinessRules = materialBusinessRules;
        }

        public async Task<GetByIdMaterialResponse> Handle(GetByIdMaterialQuery request, CancellationToken cancellationToken)
        {
            Material? material = await _materialRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _materialBusinessRules.MaterialShouldExistWhenSelected(material);

            GetByIdMaterialResponse response = _mapper.Map<GetByIdMaterialResponse>(material);
            return response;
        }
    }
}