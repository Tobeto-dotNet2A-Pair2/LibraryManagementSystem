using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Translators.Queries.GetList.GetAll;
public class GetAllTranslatorsQuery : IRequest<List<GetAllTranslatorsDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllTranslators";
    public string? CacheGroupKey => "GetTranslators";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllTranslatorsHandler : IRequestHandler<GetAllTranslatorsQuery, List<GetAllTranslatorsDto>>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public GetAllTranslatorsHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTranslatorsDto>> Handle(GetAllTranslatorsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Translator> query = _translatorRepository.Query();
            List<GetAllTranslatorsDto> allTranslators = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllTranslatorsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allTranslators;
        }
    }
}