using EH.Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EH.Assessment.Data
{
    public class EHDBContext : DbContext
    {
        public EHDBContext(DbContextOptions<EHDBContext> options) : base(options)
        {

        }


        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<ContactTypeModel> ContactTypes { get; set; }
        public DbSet<ErrorLogModel> ErrorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set Primary Keys
            modelBuilder.Entity<ContactTypeModel>()
                .HasKey(b => b.ContactTypeId);

            // Ignore property
            modelBuilder.Entity<ContactModel>().Ignore(c => c.Mode);

            // Seed Data
            modelBuilder.Entity<ContactTypeModel>()
                .HasData(
                         new ContactTypeModel { ContactType = "Employee", ContactTypeId = 1 }
                        );

            // Set Primary Key
            modelBuilder.Entity<ContactModel>()
                .HasKey(b => b.ContactId);

            modelBuilder.Entity<ErrorLogModel>()
            .HasKey(e => e.ErrorLogId);
            modelBuilder.Entity<ErrorLogModel>().Property(p => p.ErrorLogId).ValueGeneratedOnAdd();


            // Seed Data
            modelBuilder.Entity<ContactModel>()
                .HasData(
                         new ContactModel
                         {
                             FirstName = "Sachin",
                             LastName = "Jawale",
                             Email = "SachinJawale@Gmail.com",
                             Phone = "8369498118",
                             Status = true,
                             ContactId = Guid.NewGuid(),
                             ContactTypeId = 1,
                             CreatedDate = DateTime.Now,
                             LastUpdatedDate = DateTime.Now
                         },
                        new ContactModel
                        {
                            FirstName = "Akhilesh",
                            LastName = "Mishra",
                            Email = "Akhilesh_Mishra@Gmail.com",
                            Phone = "8422023641",
                            Status = false,
                            ContactId = Guid.NewGuid(),
                            ContactTypeId = 1,
                            CreatedDate = DateTime.Now,
                            LastUpdatedDate = DateTime.Now
                        }
                        );




            // Contact Table Relationship
            modelBuilder.Entity<ContactModel>()
            .HasOne<ContactTypeModel>()
            .WithMany()
            .HasForeignKey(p => p.ContactTypeId)
            .IsRequired(true);

        }

    }
}
