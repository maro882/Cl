using Clinic.Models.Entites;

namespace Clinic.Repos.Irepos
{
    public interface Idoctor
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task addDoctor(Doctor doctor);
        public Task<Doctor> getby(int id);
        public Task removeDoctor(Doctor doctor);
        public Task updateDoctor(int id,Doctor d);
    }
}
