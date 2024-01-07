using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly ClinicSysDbContext _context;

    public DoctorsController(ClinicSysDbContext context)
    {
        _context = context;
    }

    // GET: api/Doctors
    [HttpGet]
    public IEnumerable<Doctor> GetDoctors()
    {
        using (var context = new ClinicSysDbContext())
        {
            Doctor doctor = new Doctor();

            doctor.DoctorName = "ilyass";
            doctor.Specialization = "jara7";

            context.Doctors.Add(doctor);
            context.SaveChanges();

            return context.Doctors.Where(doc => doc.DoctorName == "ilyass").ToList();
        }
        
    }

    // GET: api/Doctors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return doctor;
    }

    // POST: api/Doctors
    [HttpPost]
    public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorId }, doctor);
    }

    // PUT: api/Doctors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
    {
        if (id != doctor.DoctorId)
        {
            return BadRequest();
        }

        _context.Entry(doctor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DoctorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Doctors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DoctorExists(int id)
    {
        return _context.Doctors.Any(e => e.DoctorId == id);
    }
}
