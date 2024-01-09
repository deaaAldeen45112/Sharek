using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharek.Data;
using Sharek.Models;

namespace Sharek.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly AppDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

       

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {

            return await _context.Tests.ToListAsync();
        }

    }
}
