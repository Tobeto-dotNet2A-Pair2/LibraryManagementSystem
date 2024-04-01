using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Streets.Queries.GetList;

public class GetListStreetListItemDto : IDto
{
    public Guid Id { get; set; }
    public string StreetName { get; set; }
    public Guid NeighborhoodId { get; set; }
}