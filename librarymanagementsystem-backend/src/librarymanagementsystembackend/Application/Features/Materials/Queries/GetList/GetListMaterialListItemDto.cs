using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetList;

public class GetListMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? PunishmentAmount { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; }

    //1.deneme-----
    //Bu sekilde List<GetListMaterialImageListItemDto> ...olunca: tüm  MaterialImage tablosnunveriyordu.
    //public List<GetListMaterialImageListItemDto> MaterialImages { get; set; } // MaterialImage'lerin listesi

    //2.deneme---dogru cýktý
    public List<string> ImageUrls { get; set; }
}