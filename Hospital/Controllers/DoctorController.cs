using Hospital.Data;
using Hospital.Migrations;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        public AplicationDbContext DbContext = new AplicationDbContext();
        public IActionResult Index()
        {
            var apponts = DbContext.Appointments.ToList();
            return View(apponts);
        }
        public IActionResult BookAppointment()
        {
            return View(DbContext.Doctors.ToList());
        }
        public IActionResult CompleteAppointment(int id)
        {
            var doctor = DbContext.Doctors.Find(id);
            return View(doctor);
        }
        public IActionResult Store(Appointment appointment)
        {
            if(appointment != null)
            {
                DbContext.Appointments.Add(new Appointment()
                {
                    PatientName = appointment.PatientName,
                    AppointmentDate = appointment.AppointmentDate,
                    AppointmentTime = appointment.AppointmentTime,
                    DoctorId = appointment.DoctorId
                });
                DbContext.SaveChanges();
                TempData["notifation"] = "Appointment Added successfully";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("NotFoundPage", "Home");
        }
    }
}
