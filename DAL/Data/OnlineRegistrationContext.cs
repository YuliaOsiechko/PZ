using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL.Models;

#nullable disable

namespace DAL.Data
{
    public partial class OnlineRegistrationContext : DbContext
    {
        public OnlineRegistrationContext()
        {
        }

        public OnlineRegistrationContext(DbContextOptions<OnlineRegistrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning "To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263."
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OnlineRegistration;Username=postgres;Password=qaz16073011");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("date")
                    .HasColumnName("date_time");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_doctor_id_fkey");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_patient_id_fkey");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Specielization)
                    .HasMaxLength(100)
                    .HasColumnName("specielization");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_person_id_fkey");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("hospital");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FamilyDoctorId).HasColumnName("family_doctor_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.FamilyDoctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.FamilyDoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_family_doctor_id_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_person_id_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Stuff>(entity =>
            {
                entity.ToTable("stuff");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.HospitalId).HasColumnName("hospital_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Stuffs)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stuff_doctor_id_fkey");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Stuffs)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stuff_hospital_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
