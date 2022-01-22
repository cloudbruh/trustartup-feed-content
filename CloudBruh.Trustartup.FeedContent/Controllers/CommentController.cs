using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly FeedContentContext _context;

    public CommentController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/Comment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    // GET: api/Comment/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Comment>> GetComment(long id)
    {
        Comment? comment = await _context.Comments.FindAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    // PUT: api/Comment/5
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutComment(long id, Comment comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }

        _context.Entry(comment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommentExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Comment
    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
    }

    // DELETE: api/Comment/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteComment(long id)
    {
        Comment? comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CommentExists(long id)
    {
        return _context.Comments.Any(e => e.Id == id);
    }
}