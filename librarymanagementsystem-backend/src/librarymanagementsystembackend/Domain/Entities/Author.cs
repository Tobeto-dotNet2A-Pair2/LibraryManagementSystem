using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Author : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AuthorCountry { get; set; }
    public virtual ICollection<AuthorMaterial> AuthorMaterials { get; set; }

}
