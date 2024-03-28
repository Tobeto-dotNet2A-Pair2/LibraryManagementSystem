using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Member:Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TC { get; set; }
    public string PhoneNumber { get; set; }
    public string Photograph { get; set; }
    public DateTime MemberShipDate { get; set; }
    public string? Position { get; set; }
    public string Reservation { get; set; }
    //Kütüphaneciye sorulacak konu başlığı 
    public string Messages { get; set; }
    public string AskLibrarianTopic { get; set; }
    public string AskLibrarianDescription { get; set; }
    public Guid AddressId { get; set; }
    public virtual Address? Address { get; set; }
    public Guid UserId { get; set; }

    public virtual User? User { get; set; } = null;

    //Role entity prop

}
