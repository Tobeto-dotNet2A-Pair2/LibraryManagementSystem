using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetList;

public class GetListMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}