﻿using NArchitecture.Core.Persistence.Repositories;
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
    public string Photo { get; set; }
    public string? Position { get; set; }
    public decimal TotalDebt { get; set; }
    public Guid UserId { get; set; }
    public bool isActive { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<MemberAddress> MemberAddresses { get; set; }
    public virtual ICollection<MemberContact> MemberContacts { get; set; }
    public virtual ICollection<MemberNotification> MemberNotifications { get; set; }
    public virtual ICollection<BorrowedMaterial> BorrowedMaterials { get; set; }

    public virtual ICollection<FavoriteList> FavoriteLists { get; set; }




    //Role entity prop

}
