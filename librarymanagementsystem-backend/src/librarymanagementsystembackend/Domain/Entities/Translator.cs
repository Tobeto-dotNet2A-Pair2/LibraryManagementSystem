using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Translator : Entity<Guid>
{
    public string TranslatorName { get; set; }
    public string Description { get; set; }
    public virtual ICollection<TranslatorMaterial> TranslatorMaterials { get; set; }

}
