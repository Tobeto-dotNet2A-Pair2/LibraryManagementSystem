using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialPropertyValues.Queries.GetList;

public class GetListMaterialPropertyValueListItemDto : IDto
{
    public Guid Id { get; set; }
    public string MaterialPropertyValueName { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }
}