using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StartupController : ControllerBase
{
    private readonly FeedContentContext _context;

    public StartupController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/Startup
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Startup>>> GetStartups(int count = 20, double? maxRating = null)
    {
        IQueryable<Startup> query = _context.Startups;

        if (maxRating != null)
        {
            query = query.Where(startup => startup.Rating < maxRating);
        }

        query = query.OrderByDescending(startup => startup.Rating);

        if (count >= 0)
        {
            query = query.Take(count);
        }

        return await query.ToListAsync();
    }

    // GET: api/Startup/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Startup>> GetStartup(long id)
    {
        Startup? startup = await _context.Startups.FindAsync(id);

        if (startup == null)
        {
            return NotFound();
        }

        return startup;
    }

    // PUT: api/Startup/5
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutStartup(long id, Startup startup)
    {
        if (id != startup.Id)
        {
            return BadRequest();
        }

        _context.Entry(startup).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StartupExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Startup
    [HttpPost]
    public async Task<ActionResult<Startup>> PostStartup(Startup startup)
    {
        _context.Startups.Add(startup);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStartup), new { id = startup.Id }, startup);
    }

    // DELETE: api/Startup/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteStartup(long id)
    {
        Startup? startup = await _context.Startups.FindAsync(id);
        if (startup == null)
        {
            return NotFound();
        }

        _context.Startups.Remove(startup);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    // PUT: api/Startup/5/rating
    [HttpPut("{id:long}/rating")]
    public async Task<ActionResult<Startup>> PostStartupRating(long id, StartupRatingDto startupRating)
    {
        if (id != startupRating.Id)
        {
            return BadRequest();
        }
        
        Startup? startup = await _context.Startups.FindAsync(id);
        if (startup == null)
        {
            return NotFound();
        }

        startup.Rating = startupRating.Rating;
        _context.Entry(startup).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StartupExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    private bool StartupExists(long id)
    {
        return _context.Startups.Any(e => e.Id == id);
    }
}