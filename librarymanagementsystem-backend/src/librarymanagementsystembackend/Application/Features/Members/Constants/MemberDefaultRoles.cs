using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Constants;
public static class MemberDefaultRoles
{
    public static readonly string[] Roles = ["Auth.RevokeToken","Members.Read","Members.Create","Members.Update", "Addresses.Admin","Streets.Admin" ,"Materials.Admin", "BorrowedMaterials.Create","BorrowedMaterials.Read", "BorrowedMaterials.Write","BorrowedMaterials.Update", "MaterialCopies.Read", "MaterialCopies.Write", "MaterialCopies.Create", "MaterialCopies.Update", "Locations.Admin", "MaterialGenres.Admin", "MaterialProperties.Admin", "MaterialTypes.Admin"];

  
}
