using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Application.Features.BorrowedMaterials.Queries.GetListByMember;

public class GetBorrowedMaterialListByMemberQuery : IRequest<List<GetListBorrowedMaterialListByMemberResponse>>
{
    public Guid MemberId { get; set; }
    
    public class GetListBorrowedMaterialListHandler : IRequestHandler<GetBorrowedMaterialListByMemberQuery, List<GetListBorrowedMaterialListByMemberResponse>>
    {
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly IMapper _mapper;
        
        public GetListBorrowedMaterialListHandler(IBorrowedMaterialRepository borrowedMaterialRepository, 
            IMapper mapper)
        {
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetListBorrowedMaterialListByMemberResponse>> Handle(GetBorrowedMaterialListByMemberQuery request, CancellationToken cancellationToken)
        {
            List<GetListBorrowedMaterialListByMemberResponse> borrowedMaterialList = await _borrowedMaterialRepository.Query()
                .Where(a=> a.MemberId == request.MemberId)
                .ProjectTo<GetListBorrowedMaterialListByMemberResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return borrowedMaterialList;

        }
    }
}