using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Publisher : Entity<Guid>
{
    public string Name { get; set; }
    public string PublicationPlace { get; set; }
    public Publisher() { }

    public Publisher(string name, string publicationPlace)
    {
        Name = name;
        PublicationPlace = publicationPlace;
    }

    public virtual ICollection<PublisherMaterial> PublisherMaterials { get; set; }
}
