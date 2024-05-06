using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Branches.Queries.GetList.GetAll;
public class GetAllBranchesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime WorkingHours { get; set; }
    public string PhoneNumber { get; set; }
    public string? WebSiteUrl { get; set; }
    public Guid AddressId { get; set; }
    public Guid LibraryId { get; set; }
}
