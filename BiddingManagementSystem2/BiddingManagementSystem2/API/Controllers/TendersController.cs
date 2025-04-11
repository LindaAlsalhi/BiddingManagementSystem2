using BiddingManagementSystem2.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TenderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TenderController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tenders = await _context.Tenders.Include(t => t.Bids).ToListAsync();
        return Ok(tenders);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(Tender tender)
    {
        _context.Tenders.Add(tender);
        await _context.SaveChangesAsync();
        return Ok(tender);
    }
}
