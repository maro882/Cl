using Clinic.Models.Entites;
using Clinic.Repos.Irepos;
using Clinic.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class appoimentController : Controller
    {
        private readonly Iappoiment iappoiment;
        private readonly Ipatient ipatient;
        private readonly Idoctor idoctor;
        public appoimentController(Iappoiment app, Ipatient ipatient, Idoctor idoctor)
        {
            iappoiment = app;
            this.ipatient = ipatient;
            this.idoctor = idoctor;

        }
        public async Task<IActionResult> getall()
        {
            var app = await iappoiment.GetAppointments();
            return View(app);
        }
        public async Task <IActionResult> Create()
        {
            var p = await ipatient.GetPatient();
            var d = await idoctor.GetDoctors();
            var v1 = new ViewModelAppoiment()
            {
                Doctors = d,
                Patients = p,
            };
            return View(v1);
        }
        [HttpPost]
        public async Task <IActionResult> Create(ViewModelAppoiment v1)
        {
            await iappoiment.add(v1);
            return RedirectToAction("getall");
        }
        public async Task<IActionResult> Details(int id)
        {
             var app = await iappoiment.getDetial(id);
             return View(app);  
        }
        public async Task<IActionResult> Delete(int id)
        {
            var app = await iappoiment.getby(id);
            return View(app);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Appointment app)
        {
            await iappoiment.Deleteappointment(app);
            return RedirectToAction("getall");
        }
        public async Task <IActionResult> Edit(int id)
        {
            var a = await ipatient.GetPatient();
            var d = await idoctor.GetDoctors();
            var app = await iappoiment.getby(id);
            ViewModelAppoiment appModel = new ViewModelAppoiment()
            {
                Date = app.Date,
                Notes = app.Notes,
                Doctors = d,
                Patients = a,
            };
            return View(appModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ViewModelAppoiment v1)
        {
            await iappoiment.Update(v1,id);
            return RedirectToAction("getall");
        }
    }
}
