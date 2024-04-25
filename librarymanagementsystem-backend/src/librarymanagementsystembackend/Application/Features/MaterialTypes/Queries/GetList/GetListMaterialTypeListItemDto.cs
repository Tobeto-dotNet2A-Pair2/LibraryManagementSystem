using Domain.Enums;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialTypes.Queries.GetList;

public class GetListMaterialTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }
}