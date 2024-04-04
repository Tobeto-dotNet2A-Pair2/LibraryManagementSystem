using Application.Features.BorrowedMaterials.Constants;
using Application.Features.BorrowedMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BorrowedMaterials.Constants.BorrowedMaterialsOperationClaims;

namespace Application.Features.BorrowedMaterials.Queries.GetById;

public class GetByIdBorrowedMaterialQuery : IRequest<GetByIdBorrowedMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBorrowedMaterialQueryHandler : IRequestHandler<GetByIdBorrowedMaterialQuery, GetByIdBorrowedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;

        public GetByIdBorrowedMaterialQueryHandler(IMapper mapper, IBorrowedMaterialRepository borrowedMaterialRepository, BorrowedMaterialBusinessRules borrowedMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
        }

        public async Task<GetByIdBorrowedMaterialResponse> Handle(GetByIdBorrowedMaterialQuery request, CancellationToken cancellationToken)
        {
            BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _borrowedMaterialBusinessRules.BorrowedMaterialShouldExistWhenSelected(borrowedMaterial);

            GetByIdBorrowedMaterialResponse response = _mapper.Map<GetByIdBorrowedMaterialResponse>(borrowedMaterial);
            return response;
        }
    }
}