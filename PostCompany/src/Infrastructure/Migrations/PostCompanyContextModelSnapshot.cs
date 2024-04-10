﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PostCompanyContext))]
    partial class PostCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Driver.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<long>("MissionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Drivers", "dbo");
                });

            modelBuilder.Entity("Domain.Mission.Mission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Beginning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DriverId")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Missions", "dbo");
                });

            modelBuilder.Entity("Domain.User.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Domain.Driver.Driver", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.GeoLocation", "CurrentLocation", b1 =>
                        {
                            b1.Property<long>("DriverId")
                                .HasColumnType("bigint");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<long>("DriverId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.Navigation("CurrentLocation");

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Mission.Mission", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.GeoLocation", "CurrentLocation", b1 =>
                        {
                            b1.Property<long>("MissionId")
                                .HasColumnType("bigint");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("MissionId");

                            b1.ToTable("Missions", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");
                        });

                    b.Navigation("CurrentLocation")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.User.User", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}