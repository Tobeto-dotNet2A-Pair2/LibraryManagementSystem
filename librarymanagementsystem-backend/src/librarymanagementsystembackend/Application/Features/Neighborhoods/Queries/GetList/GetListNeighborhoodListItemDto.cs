using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Neighborhoods.Queries.GetList;

public class GetListNeighborhoodListItemDto : IDto
{
    public Guid Id { get; set; }
    public string NeighborhoodName { get; set; }
    public Guid DistrictId { get; set; }
}