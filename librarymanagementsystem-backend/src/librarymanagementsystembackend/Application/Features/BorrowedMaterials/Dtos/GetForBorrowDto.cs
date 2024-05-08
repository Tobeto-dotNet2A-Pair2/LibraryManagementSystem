namespace Application.Features.BorrowedMaterials.Dtos;

public class GetForBorrowDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public byte BorrowDay { get; set; }
    public decimal PunishmentAmount { get; set; }
}