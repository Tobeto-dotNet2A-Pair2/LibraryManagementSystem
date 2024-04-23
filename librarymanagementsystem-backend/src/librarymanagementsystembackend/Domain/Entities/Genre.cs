using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Genre : Entity<Guid>
{
    public string GenreName { get; set; }

    public  virtual ICollection<MaterialGenre> MaterialGenres { get; set; }
}
