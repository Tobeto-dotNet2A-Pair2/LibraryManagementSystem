using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialImages.Queries.GetList;

public class GetListMaterialImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public Guid MaterialId { get; set; }
}