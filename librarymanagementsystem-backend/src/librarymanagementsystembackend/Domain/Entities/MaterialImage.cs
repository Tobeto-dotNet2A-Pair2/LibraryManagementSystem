using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaterialImage : Entity<Guid>
{
    public string Url { get; set; }
    public Guid MaterialId { get; set; }
    public virtual Material Material { get; set; }
}
