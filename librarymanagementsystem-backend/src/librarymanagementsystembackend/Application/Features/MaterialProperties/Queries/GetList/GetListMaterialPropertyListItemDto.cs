using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialProperties.Queries.GetList;

public class GetListMaterialPropertyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string MaterialPropertyName { get; set; }
}