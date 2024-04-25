using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Neighborhood> Neighborhoods { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public DbSet<MaterialCopy> MaterialCopies { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Translator> Translators { get; set; }
    public DbSet<FavoriteList> FavoriteLists { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<BorrowedMaterial> BorrowedMaterials { get; set; }
    public DbSet<Penalty> Penalties { get; set; }
    public DbSet<MaterialProperty> MaterialProperties { get; set; }
    public DbSet<MaterialPropertyValue> MaterialPropertyValues { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<MemberContact> MemberContacts { get; set; }
    public DbSet<AuthorMaterial> AuthorMaterials { get; set; }
    public DbSet<FavoriteListMaterial> FavoriteListMaterials { get; set; }
    public DbSet<LanguageMaterial> LanguageMaterials { get; set; }
    public DbSet<MemberAddress> MemberAddresses { get; set; }
    public DbSet<MemberNotification> MemberNotifications { get; set; }
    public DbSet<PublisherMaterial> PublisherMaterials { get; set; }
    public DbSet<TranslatorMaterial> TranslatorMaterials { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MaterialGenre> MaterialGenres { get; set; }
    public DbSet<MaterialImage> MaterialImages { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
