using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetList;

public class GetListMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    //1.deneme-----
    //Bu sekilde List<GetListMaterialImageListItemDto> ...olunca: t�m  MaterialImage tablosnunveriyordu.
    //public List<GetListMaterialImageListItemDto> MaterialImages { get; set; } // MaterialImage'lerin listesi

    //2.deneme---dogru c�kt�
    public List<string> ImageUrls { get; set; }
}