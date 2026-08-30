using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesBuzz.ReturnReasons.Api.Data;
using SalesBuzz.ReturnReasons.Api.Models;

namespace SalesBuzz.ReturnReasons.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReturnReasonsController : ControllerBase
{
    private readonly ReturnReasonsDbContext _context;

    public ReturnReasonsController(ReturnReasonsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReturnReason>>> GetReturnReasons()
    {
        var returnReasons = await _context.ReturnReasons.ToListAsync();

        return Ok(returnReasons);
    }

    [HttpPost]
    public async Task<ActionResult<ReturnReason>> CreateReturnReason(ReturnReason returnReason)
    {
        returnReason.Id = 0;

        _context.ReturnReasons.Add(returnReason);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetReturnReasons),
            new { id = returnReason.Id },
            returnReason
        );
    }

    // PUT: api/ReturnReasons/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReturnReason(
        int id,
        ReturnReason updatedReturnReason)
    {
        var returnReason = await _context.ReturnReasons.FindAsync(id);

        if (returnReason == null)
        {
            return NotFound();
        }

        returnReason.Name = updatedReturnReason.Name;
        returnReason.Description = updatedReturnReason.Description;
        returnReason.IsActive = updatedReturnReason.IsActive;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    // DELETE: api/ReturnReasons/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReturnReason(int id)
    {
        var returnReason = await _context.ReturnReasons.FindAsync(id);

        if (returnReason == null)
        {
            return NotFound();
        }

        _context.ReturnReasons.Remove(returnReason);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}