using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital
{
    public class HospitalDbContext: DbContext
    {
        public HospitalDbContext(DbContextOptions options):base(options)
        {
            
        }
        override protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctorPatients>().HasKey(p => new { p.PatientId, p.DoctorId });

            builder.Entity<Doctors>().HasMany(x => x.DoctorPatients)
                                    .WithOne(p => p.Doctors)
                                    .HasForeignKey(x => x.DoctorId);

            builder.Entity<Patients>().HasMany(x => x.DoctorPatients)
                                       .WithOne(dp => dp.Patients)
                                       .HasForeignKey(x => x.PatientId);


        }

        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Manager> Manager { get; set; }

        public DbSet<User>  Users { get; set; }
        public DbSet<DoctorPatients> DoctorPatients { get; set; }
    }
}
