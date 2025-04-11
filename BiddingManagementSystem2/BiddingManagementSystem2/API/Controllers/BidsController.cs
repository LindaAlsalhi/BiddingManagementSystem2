using BiddingManagementSystem2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BidsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BidsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceBid(Bid bid)
    {
        bid.SubmittedAt = DateTime.UtcNow;
        _context.Bids.Add(bid);
        await _context.SaveChangesAsync();
        return Ok(bid);
    }

    [HttpGet("{tenderId}")]
    public async Task<IActionResult> GetBidsForTender(int tenderId)
    {
        var bids = await _context.Bids.Where(b => b.TenderId == tenderId).ToListAsync();
        return Ok(bids);
    }
}
