using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly FeedContentContext _context;

    public LikeController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/Like
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
    {
        return await _context.Likes.ToListAsync();
    }

    // GET: api/Like/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Like>> GetLike(long id)
    {
        Like? like = await _context.Likes.FindAsync(id);

        if (like == null)
        {
            return NotFound();
        }

        return like;
    }

    // POST: api/Like
    [HttpPost]
    public async Task<ActionResult<Like>> PostLike(Like like)
    {
        _context.Likes.Add(like);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLike", new { id = like.Id }, like);
    }

    // DELETE: api/Like/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteLike(long id)
    {
        Like? like = await _context.Likes.FindAsync(id);
        if (like == null)
        {
            return NotFound();
        }

        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}