﻿// <auto-generated />
using Labb4AvancAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb4AvancAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb4Avanc.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            InterestDescription = "Rida på ryggen av en häst.",
                            InterestTitle = "Ridning"
                        },
                        new
                        {
                            InterestId = 2,
                            InterestDescription = "Lagsport med två lag där varje lag med fötterna ska försöka göra mål i motståndarnas lag.",
                            InterestTitle = "Fotboll"
                        },
                        new
                        {
                            InterestId = 3,
                            InterestDescription = "Betrakta och tolka bokstäver eller annan nedskriven information i t ex böcker och tidningar.",
                            InterestTitle = "Läsa"
                        },
                        new
                        {
                            InterestId = 4,
                            InterestDescription = "En typ av segling på vattnet på en bräda där man drivs fram av vinden med hjälp av en drake som man håller i.",
                            InterestTitle = "Kitesurfing"
                        });
                });

            modelBuilder.Entity("Labb4Avanc.Models.Leisure", b =>
                {
                    b.Property<int>("LeisureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("LeisureId");

                    b.HasIndex("PersonId");

                    b.ToTable("Leisures");
                });

            modelBuilder.Entity("Labb4Avanc.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            FirstName = "Tommy",
                            LastName = "Andersson"
                        },
                        new
                        {
                            PersonId = 2,
                            FirstName = "Annicka",
                            LastName = "Andersson"
                        },
                        new
                        {
                            PersonId = 3,
                            FirstName = "Anna",
                            LastName = "Lundgren"
                        },
                        new
                        {
                            PersonId = 4,
                            FirstName = "Johannes",
                            LastName = "Storm"
                        });
                });

            modelBuilder.Entity("Labb4Avanc.Models.Leisure", b =>
                {
                    b.HasOne("Labb4Avanc.Models.Person", "Person")
                        .WithMany("Leisure")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
