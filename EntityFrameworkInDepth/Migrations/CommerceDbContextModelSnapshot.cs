﻿// <auto-generated />
using System;
using EntityFrameworkInDepth.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkInDepth.Migrations
{
    [DbContext(typeof(CommerceDbContext))]
    partial class CommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Car", b =>
                {
                    b.Property<int>("TheCarKey")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("CarName");

                    b.HasKey("TheCarKey");

                    b.ToTable("CarTable","Vechiles");
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<TimeSpan>("CloseHour");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<TimeSpan>("OpenHour");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.StoreAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Landitute");

                    b.Property<string>("Location");

                    b.Property<double>("Longitude");

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId")
                        .IsUnique();

                    b.ToTable("StoreAddresses");
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.StoreProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.Store", b =>
                {
                    b.HasOne("EntityFrameworkInDepth.Models.Relationships.City", "City")
                        .WithMany("Stories")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.StoreAddress", b =>
                {
                    b.HasOne("EntityFrameworkInDepth.Models.Relationships.Store", "Store")
                        .WithOne("StoreAddress")
                        .HasForeignKey("EntityFrameworkInDepth.Models.Relationships.StoreAddress", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityFrameworkInDepth.Models.Relationships.StoreProduct", b =>
                {
                    b.HasOne("EntityFrameworkInDepth.Models.Relationships.Product", "Product")
                        .WithMany("StoreProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EntityFrameworkInDepth.Models.Relationships.Store", "Store")
                        .WithMany("StoreProducts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
