using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BorrowedMaterial : Entity<Guid>
{
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }

}
