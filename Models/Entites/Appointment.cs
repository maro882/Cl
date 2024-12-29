using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models.Entites
{
    public class Appointment
    {
        public int Appointmentid { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int Doctorid { get; set; }
        [ForeignKey("Doctorid")]
        public Doctor? Doctor { get; set; }
        public int Paid { get; set; }
        [ForeignKey("Paid")]
        public Patient? Patient { get; set; }
    }
}
