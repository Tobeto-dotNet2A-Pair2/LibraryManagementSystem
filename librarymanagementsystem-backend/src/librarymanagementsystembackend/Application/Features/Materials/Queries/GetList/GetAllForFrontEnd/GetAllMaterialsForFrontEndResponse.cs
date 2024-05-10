namespace Application.Features.Materials.Queries.GetList.GetAllForFrontEnd;

public class GetAllMaterialsForFrontEndResponse
{
    public GetAllMaterialsForFrontEndResponse()
    {
        ImageUrls = new List<string>();
    }
    public List<string> ImageUrls { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte BorrowDay { get; set; }
    public decimal? PunishmentAmount { get; set; }
    public bool IsBorrowable { get; set; }
}