namespace Clinic.Models.Entites
{
    public class Doctor
    {
        public int Doctorid { get; set; }   
        public string Name {  get; set; }
        public string Specialty { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
