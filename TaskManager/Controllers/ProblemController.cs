using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProblemController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProblemController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Problem>>> GetProblems()
    {
        var problems = await _context.Problems.ToListAsync();
        return await _context.Problems.ToListAsync();
        //return Ok(problems);
    }

    [HttpPost]
    public async Task<ActionResult<Problem>> PostProblem(Problem problem)
    {
        _context.Add(problem);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProblem), new { id = problem.Id }, problem);
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Problem>> GetProblem(int id)
    {
        var problem = await _context.Problems.FindAsync(id);
        if (problem == null)
        {
            return NotFound();
        }

        return problem;
    }

    [HttpPut("Id")]
    public async Task<IActionResult> UpdateProblem(int id, Problem problem)
    {
        if (id != problem.Id)
        {
            return BadRequest();
        }

        _context.Entry(problem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();

        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProblemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }

            
        }
        return NoContent();
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> DeleteProblem(int id)
    {
        var problem = await _context.Problems.FindAsync(id);
        if (problem == null)
        {
            return NotFound();
        }

        _context.Problems.Remove(problem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProblemExists(int id)
    {
        return _context.Problems.Any(task => task.Id == id);
    }
    
    
    
    
}