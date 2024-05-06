using Application.Features.Branches.Dtos;
using Application.Features.Locations.Dtos;

namespace Application.Features.MaterialCopies.Dtos;

public class MaterialCopyForMaterialDetailDto
{
    public string Status { get; set; }
    public bool IsReserved { get; set; } 
    public bool IsReservable { get; set; }
    
    public BranchForMaterialDetailDto Branch { get; set; }
    public LocationForMaterialDetailDto Location { get; set; }
}