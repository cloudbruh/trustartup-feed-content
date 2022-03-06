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
    public async Task<ActionResult<IEnumerable<Like>>> GetLikes(LikeableType? likeableType = null, long? likeableId = null)
    {
        if (likeableType == null && likeableId == null)
        {
            return await _context.Likes.ToListAsync();
        }

        if (likeableType == null || likeableId == null)
        {
            return BadRequest("LikeableType and LikeableId are needed both if any specified.");
        }
        
        return await _context.Likes
            .Where(like => like.LikeableType == likeableType && like.LikeableId == likeableId)
            .ToListAsync();
    }
    
    // GET: api/Like/count
    [HttpGet("count")]
    public async Task<ActionResult<long>> GetLikeCount(LikeableType likeableType, long likeableId)
    {
        return await _context.Likes
            .LongCountAsync(like => like.LikeableType == likeableType && like.LikeableId == likeableId);
    }
    
    // GET: api/Follow/check
    [HttpGet("check")]
    public async Task<ActionResult<bool>> GetLiked(LikeableType likeableType, long likeableId, long userId)
    {
        return await _context.Likes
                   .FirstOrDefaultAsync(like =>
                       like.LikeableType == likeableType && like.LikeableId == likeableId && like.UserId == userId) 
               != null;
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