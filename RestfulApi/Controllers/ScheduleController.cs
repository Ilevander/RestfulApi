using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SchedulesController : ControllerBase
{
    private readonly ClinicSysDbContext _context;

    public SchedulesController(ClinicSysDbContext context)
    {
        _context = context;
    }

    // GET: api/Schedules
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
    {
        return await _context.Schedules.ToListAsync();
    }

    // GET: api/Schedules/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Schedule>> GetSchedule(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);

        if (schedule == null)
        {
            return NotFound();
        }

        return schedule;
    }

    // POST: api/Schedules
    [HttpPost]
    public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
    {
        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
    }

    // PUT: api/Schedules/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
    {
        if (id != schedule.Id)
        {
            return BadRequest();
        }

        _context.Entry(schedule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ScheduleExists(id))
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

    // DELETE: api/Schedules/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchedule(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);

        if (schedule == null)
        {
            return NotFound();
        }

        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ScheduleExists(int id)
    {
        return _context.Schedules.Any(e => e.Id == id);
    }
}
