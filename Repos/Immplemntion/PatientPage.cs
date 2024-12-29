using Clinic.Models;
using Clinic.Models.Entites;
using Clinic.Repos.Irepos;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repos.Immplemntion
{
    public class PatientPage: Ipatient
    {
        private readonly AppDbContext db;
        public PatientPage(AppDbContext app)
        {
            db = app;
        }

        public async Task addPatient(Patient patient)
        {
            Patient P1 = new Patient();
            P1.Patientname = patient.Patientname;
            P1.Age = patient.Age;
            await db.Patients.AddAsync(patient);
            await db.SaveChangesAsync();
        }

        public async Task deletePatient(Patient patient)
        {
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Patient>> GetPatient()
        {
            return await db.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await db.Patients.FindAsync(id);
            return patient;
        }

        public async Task updatePatient(Patient patient, int id)
        {
            var pat =  db.Patients.FirstOrDefault(x => x.Patientid == id);
            pat.Patientname = patient.Patientname;
            pat.Age = patient.Age;
            db.Patients.Update(pat);
            await db.SaveChangesAsync();
        }
    }
}
