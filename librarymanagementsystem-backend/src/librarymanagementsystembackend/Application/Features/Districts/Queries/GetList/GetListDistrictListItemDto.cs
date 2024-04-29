using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }
}