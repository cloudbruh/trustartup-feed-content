using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaRelationshipController : ControllerBase
{
    private readonly FeedContentContext _context;

    public MediaRelationshipController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/MediaRelationship
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MediaRelationship>>> GetMediaRelationships()
    {
        return await _context.MediaRelationships.ToListAsync();
    }

    // GET: api/MediaRelationship/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<MediaRelationship>> GetMediaRelationship(long id)
    {
        MediaRelationship? mediaRelationship = await _context.MediaRelationships.FindAsync(id);

        if (mediaRelationship == null)
        {
            return NotFound();
        }

        return mediaRelationship;
    }

    // POST: api/MediaRelationship
    [HttpPost]
    public async Task<ActionResult<MediaRelationship>> PostMediaRelationship(MediaRelationship mediaRelationship)
    {
        _context.MediaRelationships.Add(mediaRelationship);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMediaRelationship", new { id = mediaRelationship.Id }, mediaRelationship);
    }

    // DELETE: api/MediaRelationship/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteMediaRelationship(long id)
    {
        MediaRelationship? mediaRelationship = await _context.MediaRelationships.FindAsync(id);
        if (mediaRelationship == null)
        {
            return NotFound();
        }

        _context.MediaRelationships.Remove(mediaRelationship);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}