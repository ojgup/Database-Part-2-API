using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_Part_2_API.Models;

namespace Database_Part_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Purchaseorder2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Purchaseorder2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Purchaseorder2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchaseorder2177>>> GetPurchaseorder2177()
        {
            return await _context.Purchaseorder2177.ToListAsync();
        }

        // GET: api/Purchaseorder2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchaseorder2177>> GetPurchaseorder2177(int id)
        {
            var purchaseorder2177 = await _context.Purchaseorder2177.FindAsync(id);

            if (purchaseorder2177 == null)
            {
                return NotFound();
            }

            return purchaseorder2177;
        }

        // PUT: api/Purchaseorder2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseorder2177(int id, Purchaseorder2177 purchaseorder2177)
        {
            if (id != purchaseorder2177.Productid)
            {
                return BadRequest();
            }

            _context.Entry(purchaseorder2177).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Purchaseorder2177Exists(id))
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

        // POST: api/Purchaseorder2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Purchaseorder2177>> PostPurchaseorder2177(Purchaseorder2177 p)
        {
            // _context.Purchaseorder2177.Add(purchaseorder2177);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC PURCHASE_STOCK " +
                    "@PPRODID = " + p.Productid +
                    ", @PLOCID = " + p.Locationid + 
                    ", @PQTY = " + p.Quantity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Purchaseorder2177Exists(p.Productid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseorder2177", new { id = p.Productid }, p);
        }

        // DELETE: api/Purchaseorder2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Purchaseorder2177>> DeletePurchaseorder2177(int id)
        {
            var purchaseorder2177 = await _context.Purchaseorder2177.FindAsync(id);
            if (purchaseorder2177 == null)
            {
                return NotFound();
            }

            _context.Purchaseorder2177.Remove(purchaseorder2177);
            await _context.SaveChangesAsync();

            return purchaseorder2177;
        }

        private bool Purchaseorder2177Exists(int id)
        {
            return _context.Purchaseorder2177.Any(e => e.Productid == id);
        }
    }
}
