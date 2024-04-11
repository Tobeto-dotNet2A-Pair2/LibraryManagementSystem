using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PublisherMaterial : Entity<Guid>
{
    public Guid PublisherId { get; set; }
    public Guid MaterialId { get; set; }

    public virtual Publisher Publisher { get; set; }
    public virtual Material Material { get; set; }
}
