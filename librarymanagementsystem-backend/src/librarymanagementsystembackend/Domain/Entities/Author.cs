using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Author : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public Author() { }
    public Author(string firstName, string lastName, string country)
    {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
    }
    public virtual ICollection<AuthorMaterial> AuthorMaterials { get; set; }

}
