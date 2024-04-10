using Domain.Mission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;
public class MissionConfiguration : IEntityTypeConfiguration<Mission>
{
    public void Configure(EntityTypeBuilder<Mission> builder)
    {
        builder.ToTable("Missions", "dbo");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(c => c.CurrentLocation, config =>
        {
            config.Property(b => b.Longitude)
                .HasColumnName("Longitude").IsRequired();
            config.Property(b => b.Latitude)
                .HasColumnName("Latitude").IsRequired();
        });
    }
}