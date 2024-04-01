using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialTypes.Queries.GetList;

public class GetListMaterialTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string MaterialTypeName { get; set; }
    public string MaterialTypeCategory { get; set; }
}