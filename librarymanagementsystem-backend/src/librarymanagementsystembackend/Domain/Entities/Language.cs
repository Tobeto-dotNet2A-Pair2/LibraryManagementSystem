using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Language:Entity<Guid>
{
    public string LanguageName { get; set; }
    public virtual ICollection<Material> Materials { get; set; }
}
