using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Materials.Queries.GetById.GetDetails;

public class GetDetailByIdForAdminQuery : IRequest<GetDetailByIdForAdminDto>
{
    public Guid Id { get; set; }
    
    public class GetDetailByIdForAdminHandler : IRequestHandler<GetDetailByIdForAdminQuery,GetDetailByIdForAdminDto>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        
        public GetDetailByIdForAdminHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        
        public async Task<GetDetailByIdForAdminDto> Handle(GetDetailByIdForAdminQuery request, CancellationToken cancellationToken)
        {
            var query = _materialRepository.Query()
                .Include(a=> a.MaterialImages)
                .Include(a => a.AuthorMaterials)
                .Include(p => p.PublisherMaterials)
                .Include(l => l.LanguageMaterials)
                .Include(t => t.TranslatorMaterials)
                .Include(mc => mc.MaterialCopies)
                .Include(g => g.MaterialGenres)
                .Include(mp => mp.MaterialPropertyValues)
                .Where(x => x.Id == request.Id)
                .ProjectTo<GetDetailByIdForAdminDto>(_mapper.ConfigurationProvider);

            var response = await query.FirstOrDefaultAsync(cancellationToken);
            return response;
        }
    }
    
}