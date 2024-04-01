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
