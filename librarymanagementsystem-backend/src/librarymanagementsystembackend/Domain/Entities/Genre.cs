using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Genre : Entity<Guid>
{
    public string Name { get; set; }
    public Genre() { }

    public Genre(string name) { Name = name; }
    public  virtual ICollection<MaterialGenre> MaterialGenres { get; set; }
}
