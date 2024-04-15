using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MemberContact : Entity<Guid>
{
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public string Messages { get; set; }
    public Guid MemberId { get; set; }
    public Guid LibraryId { get; set; }
    public virtual Member Member { get; set; }
    public virtual Library Library { get; set; }
}
