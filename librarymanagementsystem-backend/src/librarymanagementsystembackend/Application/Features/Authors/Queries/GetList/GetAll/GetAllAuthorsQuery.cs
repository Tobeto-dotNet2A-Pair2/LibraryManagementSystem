using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Authors.Queries.GetList.GetAll;
public class GetAllAuthorsQuery : IRequest<List<GetAllAuthorsDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllAuthors";
    public string? CacheGroupKey => "GetAuthors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<GetAllAuthorsDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorsHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAuthorsDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Author> query = _authorRepository.Query();
            List<GetAllAuthorsDto> allAuthors = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllAuthorsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allAuthors;
        }
    }
}

