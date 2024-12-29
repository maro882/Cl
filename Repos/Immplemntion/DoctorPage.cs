using Clinic.Models;
using Clinic.Models.Entites;
using Clinic.Repos.Irepos;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repos.Immplemntion
{
    public class DoctorPage : Idoctor
    {
        private readonly AppDbContext db;
        public DoctorPage(AppDbContext app)
        {
            db = app;
        }

        public async Task addDoctor(Doctor doctor)
        {
            var doc = new Doctor()
            {
                Name=doctor.Name,
                Specialty=doctor.Specialty,
            };
            await db.Doctors.AddAsync(doc);
            await db.SaveChangesAsync();
        }

        public async Task<Doctor> getby(int id)
        {
            var doc = await db.Doctors.FirstOrDefaultAsync(x => x.Doctorid == id);
            return doc;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await db.Doctors.ToListAsync();
        }

        public async Task removeDoctor(Doctor doctor)
        {
            db.Doctors.Remove(doctor);
            await db.SaveChangesAsync();
        }

        public async Task updateDoctor(int id,Doctor d)
        {
            var doc = await db.Doctors.FirstOrDefaultAsync(x => x.Doctorid == id);
            doc.Name = d.Name;
            doc.Specialty = d.Specialty;
            db.Doctors.Update(doc);
            await db.SaveChangesAsync();
        }
    }
}
