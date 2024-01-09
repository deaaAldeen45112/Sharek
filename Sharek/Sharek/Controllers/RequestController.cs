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
    public class RequestController : Controller
    {
        private readonly AppDbContext _context;

        public RequestController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Request
        [HttpPost]
        public async Task<IActionResult> CreateRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRequest), new { id = request.RequestId }, request);
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return request;
        }

        // PUT: api/Request/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, Request request)
        {
            if (id != request.RequestId)
            {
                return BadRequest();
            }
            _context.Entry(request).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(r => r.RequestId == id);
        }
    }

}
