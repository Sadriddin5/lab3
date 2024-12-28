using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysProgLab3.Models;
namespace SysProgLab3.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    [Authorize]
    public class PriceController:Controller
    {
        private DataContext db;
        public PriceController(DataContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        public IAsyncEnumerable<PriceCurant> GetPrices()
        {
            return db.PriceCurants.AsAsyncEnumerable();
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult?> GetPrice(long id)
        {
            PriceCurant? price = await db.PriceCurants.
                FirstOrDefaultAsync(s => s.CodeGood == id);
            if (price != null)
            {
              return Ok(price);
            }
            return NotFound();
           
        }
        [HttpPost]
        public async Task<IActionResult> SavePrice([FromBody] PriceCurant price)
        {
            await db.PriceCurants.AddAsync(price);
            await db.SaveChangesAsync();
            return Ok(price);
        }
        [HttpPut/*("{codeGood}")*/]
        public async Task<IActionResult> UpdatePrice(PriceCurant price)
        {
            PriceCurant? p = await db.PriceCurants.FindAsync(price.CodeGood);
            if (p == null) return NotFound();

            p.NameGood = price.NameGood; 
            p.PriceGood = price.PriceGood;
           

            await db.SaveChangesAsync(); 
            return Ok(p);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrice(long id)
        {
            PriceCurant? p = await db.PriceCurants.FindAsync(id);
            if (p == null) return NotFound();
            db.PriceCurants.Remove(p);
            await db.SaveChangesAsync();
            return Ok(p);
        }
        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetPrice), new { Id = 1 });
        }
    }
}
