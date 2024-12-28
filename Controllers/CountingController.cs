using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysProgLab3.Models;

namespace SysProgLab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CountingController:Controller
    {
        private DataContext db;
        public CountingController(DataContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        public IAsyncEnumerable<AccountingGoods> GetCountings()
        {
            return db.AccountingGoods.AsAsyncEnumerable();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult?> GetCount(long id)
        {
            AccountingGoods? counting = await db.AccountingGoods.FirstOrDefaultAsync(s => s.IDCounting == id);
            if (counting != null)
            {
                return Ok(counting);
            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> SaveCount([FromBody] AccountingGoods count)
        {
            await db.AccountingGoods.AddAsync(count);
            await db.SaveChangesAsync();
            return Ok(count);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCount(AccountingGoods count)
        {
            AccountingGoods? p = await db.AccountingGoods.FindAsync(count.CodeGood);
            if (p == null) return NotFound();
            db.Update(count);
            await db.SaveChangesAsync();
            return Ok(count);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCount(long id)
        {
            AccountingGoods? ac = await db.AccountingGoods.FindAsync(id);
            if (ac == null) return NotFound();
            db.AccountingGoods.Remove(ac);
            await db.SaveChangesAsync();
            return Ok(ac);
        }
        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetCountings), new { Id = 1 });
        }
    }
}
