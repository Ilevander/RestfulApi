using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PermissionsController : ControllerBase
{
    private readonly ClinicSysDbContext _context;

    public PermissionsController(ClinicSysDbContext context)
    {
        _context = context;
    }

    // GET: api/Permissions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
    {
        return await _context.Permissions.ToListAsync();
    }

    // GET: api/Permissions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Permission>> GetPermission(int id)
    {
        var permission = await _context.Permissions.FindAsync(id);

        if (permission == null)
        {
            return NotFound();
        }

        return permission;
    }

    // POST: api/Permissions
    [HttpPost]
    public async Task<ActionResult<Permission>> PostPermission(Permission permission)
    {
        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permission);
    }

    // PUT: api/Permissions/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPermission(int id, Permission permission)
    {
        if (id != permission.Id)
        {
            return BadRequest();
        }

        _context.Entry(permission).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PermissionExists(id))
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

    // DELETE: api/Permissions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePermission(int id)
    {
        var permission = await _context.Permissions.FindAsync(id);

        if (permission == null)
        {
            return NotFound();
        }

        _context.Permissions.Remove(permission);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PermissionExists(int id)
    {
        return _context.Permissions.Any(e => e.Id == id);
    }
}
