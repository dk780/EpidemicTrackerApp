using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApp.Models;
namespace EpidemicTrackerApp.Models
{
    public class EpidemicTrackerAppDBContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Occupation> Occupations { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Role> Roles { get; set; }



        public DbSet<TreatmentRecords> TreatmentRecords { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=.;Initial Catalog=ETAppDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientID);
                entity.Property(p => p.PatientName).HasColumnName("PatientName").HasColumnType("varchar").HasMaxLength(100).IsRequired();
                entity.Property(p => p.PAge).HasColumnName("Age").HasMaxLength(3).IsRequired();
                entity.Property(p => p.PGender).HasColumnName("Gender").HasMaxLength(6).IsRequired();
                entity.Property(p => p.PEmail).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(30).IsRequired();
                entity.Property(p => p.AadharID).HasColumnName("UniquesId").HasMaxLength(25).IsRequired();
                entity.Property(p => p.PContact).HasColumnName("Contact").HasMaxLength(15).IsRequired();

            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(adr => adr.AddressId);
                entity.Property(adr => adr.AddressType).HasColumnName("AddressType").HasMaxLength(50).IsRequired();
                entity.Property(adr => adr.StreetNo).HasColumnName("StreetNumber").HasColumnType("int").HasMaxLength(15).IsRequired();
                entity.Property(adr => adr.Area).HasColumnName("Area").HasColumnType("varchar").HasMaxLength(50).IsRequired();
                entity.Property(adr => adr.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(50).IsRequired();
                entity.Property(adr => adr.State).HasColumnName("State").HasColumnType("varchar").HasMaxLength(50).IsRequired();
                entity.Property(adr => adr.Country).HasColumnName("Country").HasColumnType("varchar").HasMaxLength(30).IsRequired();
                entity.Property(adr => adr.ZipCode).HasColumnName("Pin Code").HasColumnType("int").HasMaxLength(10).IsRequired();
                entity.HasOne(p => p.Patient).WithOne(adr=>adr.Address).HasForeignKey<Patient>(adr=>adr.AddressId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(h => h.Hospitals).WithOne(adr => adr.Address).HasForeignKey<Hospital>(adr => adr.AddressId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(org => org.Organisations).WithOne(adr => adr.Address).HasForeignKey<Organisation>(adr => adr.AddressId).OnDelete(DeleteBehavior.NoAction);


            });

            

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(h => h.HospitalId);
                entity.Property(h => h.HospitalName).HasColumnName("HospitalName").HasColumnType("varchar").HasMaxLength(30).IsRequired();
                entity.Property(h => h.Contact).HasColumnName("PhoneNumber").HasColumnType("varchar").HasMaxLength(15).IsRequired();


            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(l => l.LoginId);
                entity.Property(l => l.Name).HasColumnName("Login Name").IsRequired();
                entity.Property(l => l.Gender).HasColumnName("Gender").IsRequired();
                entity.Property(l => l.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(20).IsRequired();
                entity.Property(l => l.Contact).HasColumnName("PhoneNumber").IsRequired();
                entity.Property(l => l.Password).HasColumnName("Password").IsRequired();
                entity.Property(l => l.ConfirmPassword).HasColumnName("ConfirmPassword").IsRequired();

                entity.HasOne<Role>(r => r.Role).WithMany(l => l.Logins).HasForeignKey(r => r.RoleId);
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.HasKey(occ => occ.OccupationId);
                entity.Property(occ => occ.OccupationName).HasColumnName("Occupation Name").HasColumnType("varchar").HasMaxLength(30).IsRequired();
                entity.Property(occ => occ.OccupationType).HasColumnName("Occupation Type").HasColumnType("varchar").HasMaxLength(20).IsRequired();
                entity.HasOne<Patient>(p => p.Patient).WithOne(ocp => ocp.Occupation).HasForeignKey<Occupation>(p => p.PatientID).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.HasKey(d => d.DiseaseId);
                entity.Property(d => d.DiseaseName).HasColumnName("Disease Name").HasColumnType("varchar").HasMaxLength(30).IsRequired();
                entity.Property(d => d.DiseaseType).HasColumnName("DiseaseType").HasColumnType("varchar").HasMaxLength(30).IsRequired();

            });

            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.HasKey(org => org.OrganisationId);
                entity.Property(org => org.OrganisationName).HasColumnName("OrganisationName").HasColumnType("varchar").HasMaxLength(25).IsRequired();
                entity.Property(org => org.OrganisationContact).HasColumnName("PhoneNumber").HasMaxLength(15).IsRequired();

                entity.HasOne<Patient>(p => p.Patient).WithOne(org => org.Organisation).HasForeignKey<Organisation>(p => p.PatientID).OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);
                entity.Property(r => r.RoleName).HasColumnName("RoleName");

            });

            modelBuilder.Entity<TreatmentRecords>(entity =>
            {
                entity.HasKey(tr => tr.TreatmentRecordsId);
                entity.Property(tr => tr.AdmittedDate).HasColumnName("Admitted Date").HasColumnType("date").IsRequired();
                entity.Property(tr => tr.RelievingDate).HasColumnName("Relieving Date").HasColumnType("date").IsRequired();
                entity.Property(tr => tr.Prescription).HasColumnName("Prescription").IsRequired();
                entity.Property(tr => tr.Currentstage).HasColumnName("Current Stage").IsRequired();
                entity.Property(tr => tr.IsFatal).HasColumnName("IsFatal").IsRequired();

                entity.HasOne<Patient>(p => p.Patient).WithMany(tr => tr.TreatmentRecords).HasForeignKey(p => p.PatientID);

                entity.HasOne<Hospital>(h => h.Hospital).WithMany(tr => tr.TreatmentRecords).HasForeignKey(h => h.HospitalId);

                entity.HasOne<Disease>(d => d.Disease).WithMany(tr => tr.TreatmentRecords).HasForeignKey(d => d.DiseaseId);
            });




        }
    }
}

