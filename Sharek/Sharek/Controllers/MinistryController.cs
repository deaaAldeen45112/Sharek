using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
using Sharek.Data;
using Sharek.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

namespace Sharek.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MinistryController : Controller
    {
        private readonly AppDbContext _context;

        public MinistryController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Ministry
        [HttpPost]
        public async Task<IActionResult> CreateMinistry(Ministry ministry)
        {
            _context.Ministries.Add(ministry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMinistry), new { id = ministry.MinistryId }, ministry);
        }

        // GET: api/Ministry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ministry>>> GetMinistries()
        {
            return await _context.Ministries.ToListAsync();
        }

        // GET: api/Ministry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ministry>> GetMinistry(int id)
        {
            var ministry = await _context.Ministries.FindAsync(id);
            if (ministry == null)
            {
                return NotFound();
            }
            return ministry;
        }

        // PUT: api/Ministry/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMinistry(int id, Ministry ministry)
        {
            if (id != ministry.MinistryId)
            {
                return BadRequest();
            }
            _context.Entry(ministry).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryExists(id))
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

        // DELETE: api/Ministry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistry(int id)
        {
            var ministry = await _context.Ministries.FindAsync(id);
            if (ministry == null)
            {
                return NotFound();
            }
            _context.Ministries.Remove(ministry);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool MinistryExists(int id)
        {
            return _context.Ministries.Any(m => m.MinistryId == id);
        }
    }

}
