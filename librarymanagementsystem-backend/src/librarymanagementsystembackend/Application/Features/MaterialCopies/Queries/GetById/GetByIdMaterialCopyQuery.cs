using Application.Features.MaterialCopies.Constants;
using Application.Features.MaterialCopies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialCopies.Constants.MaterialCopiesOperationClaims;

namespace Application.Features.MaterialCopies.Queries.GetById;

public class GetByIdMaterialCopyQuery : IRequest<GetByIdMaterialCopyResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialCopyQueryHandler : IRequestHandler<GetByIdMaterialCopyQuery, GetByIdMaterialCopyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly MaterialCopyBusinessRules _materialCopyBusinessRules;

        public GetByIdMaterialCopyQueryHandler(IMapper mapper, IMaterialCopyRepository materialCopyRepository, MaterialCopyBusinessRules materialCopyBusinessRules)
        {
            _mapper = mapper;
            _materialCopyRepository = materialCopyRepository;
            _materialCopyBusinessRules = materialCopyBusinessRules;
        }

        public async Task<GetByIdMaterialCopyResponse> Handle(GetByIdMaterialCopyQuery request, CancellationToken cancellationToken)
        {
            MaterialCopy? materialCopy = await _materialCopyRepository.GetAsync(predicate: mc => mc.Id == request.Id, cancellationToken: cancellationToken);
            await _materialCopyBusinessRules.MaterialCopyShouldExistWhenSelected(materialCopy);

            GetByIdMaterialCopyResponse response = _mapper.Map<GetByIdMaterialCopyResponse>(materialCopy);
            return response;
        }
    }
}