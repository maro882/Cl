using Clinic.Models.Entites;
using Clinic.Repos.Irepos;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Idoctor idoctor;
        public DoctorController(Idoctor idoctor1)
        {
            idoctor = idoctor1;
        }
        public async Task<IActionResult> getall()
        {
            var doc = await idoctor.GetDoctors();
            return View(doc);   
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            await idoctor.addDoctor(doctor);
            return RedirectToAction("getall");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id )
        {
            var doc = await idoctor.getby(id);
            return View(doc);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Doctor d1)
        {
            await idoctor.removeDoctor(d1);
            return RedirectToAction("getall");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doc = await idoctor.getby(id);
            return View(doc);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Doctor doc)
        {
            await idoctor.updateDoctor(id, doc);
            return RedirectToAction("getall");
        }
    }
}
