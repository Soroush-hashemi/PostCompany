using Domain.Driver;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configuration;
public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("Drivers", "dbo");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(c => c.PhoneNumber, config =>
        {
            config.Property(b => b.Value)
                .HasColumnName("PhoneNumber")
                .IsRequired().HasMaxLength(11);
        });

        builder.OwnsOne(c => c.CurrentLocation, config =>
        {
            config.Property(b => b.Longitude)
                .HasColumnName("Longitude");
            config.Property(b => b.Latitude)
                .HasColumnName("Latitude");
        });

    }
}