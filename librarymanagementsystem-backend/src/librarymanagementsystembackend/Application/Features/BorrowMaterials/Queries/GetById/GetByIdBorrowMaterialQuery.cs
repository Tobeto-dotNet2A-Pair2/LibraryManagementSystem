using Application.Features.BorrowMaterials.Constants;
using Application.Features.BorrowMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BorrowMaterials.Constants.BorrowMaterialsOperationClaims;

namespace Application.Features.BorrowMaterials.Queries.GetById;

public class GetByIdBorrowMaterialQuery : IRequest<GetByIdBorrowMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBorrowMaterialQueryHandler : IRequestHandler<GetByIdBorrowMaterialQuery, GetByIdBorrowMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowMaterialRepository _borrowMaterialRepository;
        private readonly BorrowMaterialBusinessRules _borrowMaterialBusinessRules;

        public GetByIdBorrowMaterialQueryHandler(IMapper mapper, IBorrowMaterialRepository borrowMaterialRepository, BorrowMaterialBusinessRules borrowMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowMaterialRepository = borrowMaterialRepository;
            _borrowMaterialBusinessRules = borrowMaterialBusinessRules;
        }

        public async Task<GetByIdBorrowMaterialResponse> Handle(GetByIdBorrowMaterialQuery request, CancellationToken cancellationToken)
        {
            BorrowMaterial? borrowMaterial = await _borrowMaterialRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _borrowMaterialBusinessRules.BorrowMaterialShouldExistWhenSelected(borrowMaterial);

            GetByIdBorrowMaterialResponse response = _mapper.Map<GetByIdBorrowMaterialResponse>(borrowMaterial);
            return response;
        }
    }
}