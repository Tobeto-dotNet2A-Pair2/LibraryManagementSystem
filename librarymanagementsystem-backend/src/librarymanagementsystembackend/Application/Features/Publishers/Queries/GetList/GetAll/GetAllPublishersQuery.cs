using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Publishers.Queries.GetList.GetAll;
public class GetAllPublishersQuery : IRequest<List<GetAllPublishersDto>>
{
    public bool BypassCache { get; }
    public string? CacheKey => $"GetAllPublishers";
    public string? CacheGroupKey => "GetPublishers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetAllPublishersHandler : IRequestHandler<GetAllPublishersQuery, List<GetAllPublishersDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetAllPublishersHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPublishersDto>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Publisher> query = _publisherRepository.Query();
            List<GetAllPublishersDto> allPublishers = await query
                .Where(a => a.DeletedDate == null)
                .ProjectTo<GetAllPublishersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return allPublishers;
        }
    }
}