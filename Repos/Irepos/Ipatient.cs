using Clinic.Models.Entites;

namespace Clinic.Repos.Irepos
{
    public interface Ipatient
    {
        public Task<IEnumerable<Patient>> GetPatient();
        public Task addPatient(Patient patient);
        public Task<Patient> GetPatient(int id);
        public Task deletePatient(Patient patient);
        public Task updatePatient(Patient patient,int id);
    }
}
