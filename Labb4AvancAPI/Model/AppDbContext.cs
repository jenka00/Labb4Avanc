using Labb4Avanc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvancAPI.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }  
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, 
                    FirstName = "Tommy", 
                    LastName = "Andersson", 
                    Phone = "0736334987" });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 2, 
                    FirstName = "Annicka", 
                    LastName = "Andersson", 
                    Phone = "089954534" });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person 
                { PersonId = 3, 
                    FirstName = "Anna", 
                    LastName = "Lundgren",
                    Phone = "031223344"
                });


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 4,
                    FirstName = "Johannes",
                    LastName = "Storm",
                    Phone = "0702112233"
                });

            modelBuilder.Entity<Interest>().HasData(
               new Interest
               {
                   InterestId = 1,
                   InterestTitle = "Ridning",
                   InterestDescription = "Rida på ryggen av en häst.",
                   PersonId = 2
               });
            modelBuilder.Entity<Interest>().HasData(
           new Interest
           {
               InterestId = 2,
               InterestTitle = "Fotboll",
               InterestDescription = "Lagsport med två lag där varje lag med fötterna " +
               "ska försöka göra mål i motståndarnas lag.",
               PersonId = 1
           
           });
            modelBuilder.Entity<Interest>().HasData(
            new Interest
            {
                InterestId = 3,
                InterestTitle = "Läsa",
                InterestDescription = "Betrakta och tolka bokstäver eller annan nedskriven information i " +
                 "t ex böcker och tidningar.",
                PersonId = 3,
                
            });
            modelBuilder.Entity<Interest>().HasData(
           new Interest
           {
               InterestId = 4,
               InterestTitle = "Kitesurfing",
               InterestDescription = "En typ av segling på vattnet på en bräda där man drivs fram av vinden med hjälp av en " +
               "drake som man håller i." ,
               PersonId = 1
           });
        }
    }
}
