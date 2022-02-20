using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly FeedContentContext _context;

    public PostController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/Post
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts(long? startupId = null)
    {
        if (startupId == null)
        {
            return await _context.Posts.ToListAsync();
        }
        
        return await _context.Posts.Where(post => post.StartupId == startupId).ToListAsync();
    }

    // GET: api/Post/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Post>> GetPost(long id)
    {
        Post? post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        return post;
    }

    // PUT: api/Post/5
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutPost(long id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }

        _context.Entry(post).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Post
    [HttpPost]
    public async Task<ActionResult<Post>> PostPost(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPost", new { id = post.Id }, post);
    }

    // DELETE: api/Post/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeletePost(long id)
    {
        Post? post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PostExists(long id)
    {
        return _context.Posts.Any(e => e.Id == id);
    }
}