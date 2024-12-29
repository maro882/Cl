using Clinic.Models.Entites;
using Clinic.ViewModel;

namespace Clinic.Repos.Irepos
{
    public interface Iappoiment
    {
        public Task<IEnumerable<Appointment>> GetAppointments();
        public Task add(ViewModelAppoiment v1);
        public Task<Appointment> getDetial(int id);
        public Task<Appointment> getby(int id);
        public Task Deleteappointment(Appointment appoiment);
        public Task Update(ViewModelAppoiment v1,int id);
    }
}
