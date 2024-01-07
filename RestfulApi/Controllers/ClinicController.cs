using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly ClinicSysDbContext _context;

    public ClinicsController(ClinicSysDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // GET: api/Clinics
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clinic>>> GetClinics()
    {
        return await _context.Clinics.ToListAsync();
    }

    // GET: api/Clinics/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Clinic>> GetClinic(int id)
    {
        var clinic = await _context.Clinics.FindAsync(id);

        if (clinic == null)
        {
            return NotFound();
        }

        return clinic;
    }

    // POST: api/Clinics
    [HttpPost]
    public async Task<ActionResult<Clinic>> PostClinic(Clinic clinic)
    {
        _context.Clinics.Add(clinic);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClinic), new { id = clinic.ClinicId }, clinic);
    }

    // PUT: api/Clinics/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClinic(int id, Clinic clinic)
    {
        if (id != clinic.ClinicId)
        {
            return BadRequest();
        }

        _context.Entry(clinic).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClinicExists(id))
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

    // DELETE: api/Clinics/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinic(int id)
    {
        var clinic = await _context.Clinics.FindAsync(id);

        if (clinic == null)
        {
            return NotFound();
        }

        _context.Clinics.Remove(clinic);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClinicExists(int id)
    {
        return _context.Clinics.Any(e => e.ClinicId == id);
    }
}
