using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Address : Entity<Guid>
{
    public Guid StreetId { get; set; }
    public string AddressName { get; set; }
    public string Description { get; set; }

    public virtual Street? Street { get; set; }
    public virtual Branch? Branch { get; set; } //?

}
