using Microsoft.AspNetCore.Mvc;
using Hospitalsystem.Data;
using Hospitalsystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospitalsystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly HospitalContext _context;

        public AppointmentController(HospitalContext context)
        {
            _context = context;
        }

        // GET ALL APPOINTMENTS
        [HttpGet]
        public IActionResult GetAppointments()
        {
            var data = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToList();

            return Ok(data);
        }

        // CREATE APPOINTMENT
        [HttpPost]
        public IActionResult AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return Ok(appointment);
        }
    }
}