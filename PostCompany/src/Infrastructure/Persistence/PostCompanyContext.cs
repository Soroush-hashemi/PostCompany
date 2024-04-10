using Common.Domain.Bases;
using Domain.Driver;
using Domain.Mission;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class PostCompanyContext : DbContext
{
    public PostCompanyContext()
    {

    }

    public PostCompanyContext(DbContextOptions<PostCompanyContext> options) : base(options)
    {

    }

    public DbSet<Mission> Missions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Driver> Drivers { get; set; }

    private List<BaseEntity> GetModifiedEntities() =>
    ChangeTracker.Entries<BaseEntity>()
        .Where(x => x.State != EntityState.Detached)
        .Select(c => c.Entity)
        .Where(c => c.DomainEvents.Any()).ToList();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostCompanyContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}