using Clinic.Models;
using Clinic.Models.Entites;
using Clinic.Repos.Irepos;
using Clinic.ViewModel;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic.Repos.Immplemntion
{
    public class AppoimentPage : Iappoiment
    {
        private readonly AppDbContext db;
        public AppoimentPage(AppDbContext app)
        {
            db = app;
        }

        public async Task add(ViewModelAppoiment v1)
        {
            var app = new Appointment()
            {
                Date = v1.Date,
                Notes = v1.Notes,
                Doctorid = v1.Doctorid,
                Paid = v1.Paid,
            };
            await db.Appointments.AddAsync(app);
            await db.SaveChangesAsync();
        }

        public async Task Deleteappointment(Appointment appoiment)
        {
            db.Appointments.Remove(appoiment);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var app = await db.Appointments.ToListAsync();
            return app;
        }

        public async  Task<Appointment> getby(int id)
        {
            var app = await db.Appointments.Include(x => x.Doctor).Include(y => y.Patient).FirstOrDefaultAsync(x => x.Appointmentid == id);
            return app;
        }

        public async Task<Appointment> getDetial(int id)
        {
            var app = await db.Appointments.Include(x => x.Doctor).Include(y => y.Patient).FirstOrDefaultAsync(x =>x.Appointmentid == id);
            return app;
        }

        public async Task Update(ViewModelAppoiment v1, int id)
        {
            var appoiment = await db.Appointments.Include(x => x.Doctor).Include(y => y.Patient).FirstOrDefaultAsync(x => x.Appointmentid == id);
            appoiment.Date = v1.Date;
            appoiment.Notes = v1.Notes;
            appoiment.Doctorid = v1.Doctorid;
            appoiment.Paid = v1.Paid;
            db.Appointments.Update(appoiment);
            await db.SaveChangesAsync();
        }
    }
}
