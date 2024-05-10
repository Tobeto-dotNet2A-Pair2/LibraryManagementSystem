using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaterialCopies.Queries.GetById.GetDetails;

public class GetDetailByIdForAdminQuery : IRequest<GetDetailByIdForAdminDto>
{
    public Guid Id { get; set; }

    public GetDetailByIdForAdminQuery()
    {
        
    }

    public class GetDetailByIdForAdminHandler : IRequestHandler<GetDetailByIdForAdminQuery, GetDetailByIdForAdminDto>
    {
        private readonly IMaterialCopyRepository _materialCopyRepository;
        private readonly IMapper _mapper;
        
        public GetDetailByIdForAdminHandler(IMaterialCopyRepository materialCopyRepository, IMapper mapper)
        {
            _materialCopyRepository = materialCopyRepository;
            _mapper = mapper;
        }
        
        public async Task<GetDetailByIdForAdminDto> Handle(GetDetailByIdForAdminQuery request, CancellationToken cancellationToken)
        {
            GetDetailByIdForAdminDto result = await _materialCopyRepository.Query()
                .Where(x => x.Id == request.Id)
                .ProjectTo<GetDetailByIdForAdminDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
    
}