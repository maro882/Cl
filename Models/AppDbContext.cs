using Clinic.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasOne(x => x.Patient).WithMany(o => o.Appointments).HasForeignKey( x => x.Paid );
            modelBuilder.Entity<Appointment>().HasOne(x => x.Doctor).WithMany(o => o.Appointments).HasForeignKey(x => x.Doctorid);
        }
    }
}
