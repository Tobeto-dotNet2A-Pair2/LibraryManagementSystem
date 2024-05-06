using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Languages.Queries.GetList.GetAll;
public class GetAllLanguagesQuery : IRequest<List<GetAllLanguagesDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllLanguages";
    public string? CacheGroupKey => "GetLanguages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllLanguagesHandler : IRequestHandler<GetAllLanguagesQuery, List<GetAllLanguagesDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetAllLanguagesHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllLanguagesDto>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Language> query = _languageRepository.Query();
            List<GetAllLanguagesDto> allLanguages = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllLanguagesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allLanguages;
        }
    }
}
