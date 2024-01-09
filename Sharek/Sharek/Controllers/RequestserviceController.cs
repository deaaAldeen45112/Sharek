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
    public class RequestserviceController : Controller
    {
        private readonly AppDbContext _context;

        public RequestserviceController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Requestservice
        [HttpPost]
        public async Task<IActionResult> CreateRequestservice(Requestservice requestservice)
        {
            _context.Requestservices.Add(requestservice);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRequestservice), new { id = requestservice.RequestServiceId }, requestservice);
        }

        // GET: api/Requestservice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestservice>>> GetRequestservices()
        {
            return await _context.Requestservices.ToListAsync();
        }

        // GET: api/Requestservice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestservice>> GetRequestservice(int id)
        {
            var requestservice = await _context.Requestservices.FindAsync(id);
            if (requestservice == null)
            {
                return NotFound();
            }
            return requestservice;
        }

        // PUT: api/Requestservice/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestservice(int id, Requestservice requestservice)
        {
            if (id != requestservice.RequestServiceId)
            {
                return BadRequest();
            }
            _context.Entry(requestservice).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestserviceExists(id))
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

        // DELETE: api/Requestservice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestservice(int id)
        {
            var requestservice = await _context.Requestservices.FindAsync(id);
            if (requestservice == null)
            {
                return NotFound();
            }
            _context.Requestservices.Remove(requestservice);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RequestserviceExists(int id)
        {
            return _context.Requestservices.Any(rs => rs.RequestServiceId == id);
        }
    }

}
