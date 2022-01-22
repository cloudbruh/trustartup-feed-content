using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowController : ControllerBase
{
    private readonly FeedContentContext _context;

    public FollowController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/Follow
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Follow>>> GetFollows()
    {
        return await _context.Follows.ToListAsync();
    }

    // GET: api/Follow/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Follow>> GetFollow(long id)
    {
        Follow? follow = await _context.Follows.FindAsync(id);

        if (follow == null)
        {
            return NotFound();
        }

        return follow;
    }

    // POST: api/Follow
    [HttpPost]
    public async Task<ActionResult<Follow>> PostFollow(Follow follow)
    {
        _context.Follows.Add(follow);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFollow", new { id = follow.Id }, follow);
    }

    // DELETE: api/Follow/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteFollow(long id)
    {
        Follow? follow = await _context.Follows.FindAsync(id);
        if (follow == null)
        {
            return NotFound();
        }

        _context.Follows.Remove(follow);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}