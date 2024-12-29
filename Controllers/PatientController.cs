using Clinic.Models.Entites;
using Clinic.Repos.Irepos;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class PatientController : Controller
    {
        private readonly Ipatient ipatient;
        public PatientController(Ipatient ipatient1)
        {
            ipatient = ipatient1;
        }
        public async Task<IActionResult> getallPatient()
        {
            var pat = await ipatient.GetPatient();
            return View(pat);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(Patient p1)
        {
            await ipatient.addPatient(p1);
            return RedirectToAction("getallPatient");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pat = await ipatient.GetPatient(id);
            return View(pat);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Patient p1)
        {
            await ipatient.deletePatient(p1);
            return RedirectToAction("getallPatient");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pat = await ipatient.GetPatient(id);
            return View(pat);
        }
        [HttpPost] 
        public async Task<IActionResult> Edit(Patient patient,int id)
        {
            await ipatient.updatePatient(patient, id);
            return RedirectToAction("getallPatient");
        }
    }
}
