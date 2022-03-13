using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBruh.Trustartup.FeedContent.Models;

namespace CloudBruh.Trustartup.FeedContent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RewardController : ControllerBase
{
    private readonly FeedContentContext _context;

    public RewardController(FeedContentContext context)
    {
        _context = context;
    }

    // GET: api/Reward
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reward>>> GetRewards(long? startupId = null)
    {
        if (startupId == null)
        {
            return await _context.Rewards.ToListAsync();
        }
        
        return await _context.Rewards
            .Where(reward => reward.StartupId == startupId)
            .ToListAsync();
    }

    // GET: api/Reward/5
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Reward>> GetReward(long id)
    {
        Reward? reward = await _context.Rewards.FindAsync(id);

        if (reward == null)
        {
            return NotFound();
        }

        return reward;
    }

    // PUT: api/Reward/5
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutReward(long id, Reward reward)
    {
        if (id != reward.Id)
        {
            return BadRequest();
        }

        _context.Entry(reward).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RewardExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Reward
    [HttpPost]
    public async Task<ActionResult<Reward>> PostReward(Reward reward)
    {
        _context.Rewards.Add(reward);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReward", new { id = reward.Id }, reward);
    }

    // DELETE: api/Reward/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteReward(long id)
    {
        Reward? reward = await _context.Rewards.FindAsync(id);
        if (reward == null)
        {
            return NotFound();
        }

        _context.Rewards.Remove(reward);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RewardExists(long id)
    {
        return _context.Rewards.Any(e => e.Id == id);
    }
}