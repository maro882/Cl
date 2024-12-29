namespace Clinic.Models.Entites
{
    public class Patient
    {
        public int Patientid { get; set; }  
        public string Patientname { get; set;}
        public int Age { get; set;}
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
