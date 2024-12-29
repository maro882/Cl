using Clinic.Models.Entites;

namespace Clinic.ViewModel
{
    public class ViewModelAppoiment
    {
        public int Appointmentid { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int Doctorid { get; set; }
        public IEnumerable<Doctor>? Doctors { get; set; }
        public int Paid { get; set; }
        public IEnumerable<Patient>? Patients { get; set; }
    }
}
