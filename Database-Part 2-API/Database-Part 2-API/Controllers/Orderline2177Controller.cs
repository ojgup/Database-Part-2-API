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
    public class Orderline2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Orderline2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Orderline2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderline2177>>> GetOrderline2177()
        {
            return await _context.Orderline2177.ToListAsync();
        }

        // GET: api/Orderline2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderline2177>> GetOrderline2177(int id)
        {
            var orderline2177 = await _context.Orderline2177.FindAsync(id);

            if (orderline2177 == null)
            {
                return NotFound();
            }

            return orderline2177;
        }

        // PUT: api/Orderline2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderline2177(int id, Orderline2177 orderline2177)
        {
            if (id != orderline2177.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(orderline2177).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Orderline2177Exists(id))
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

        // POST: api/Orderline2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orderline2177>> PostOrderline2177(Orderline2177 ol)
        {
            // _context.Orderline2177.Add(ol);
            try
            {

                await _context.Database.ExecuteSqlRawAsync("EXEC ADD_PRODUCT_TO_ORDER @PORDERID = " + ol.Orderid + 
                    ", @PPRODIID = " + ol.Productid +
                    ", @PQTY = " + ol.Quantity +
                    ", @DISCOUNT = " + ol.Discount);
            }
            catch (DbUpdateException)
            {
                if (Orderline2177Exists(ol.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderline2177", new { id = ol.Orderid }, ol);
        }

        // DELETE: api/Orderline2177/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteOrderline2177(Orderline2177 ol )
        {
            // var orderline2177 = await _context.Orderline2177.FindAsync(id);

            var order = await _context.Database.ExecuteSqlRawAsync("EXEC REMOVE_PRODUCT_FROM_ORDER " +
                "@PORDERID = " + ol.Orderid + ", @PPRODIID = " + ol.Productid);
            /*
            if (order == null)
            {
                return NotFound();
            }*/
            if (order == 0)
            {
                return -1;
            }


            // _context.Orderline2177.Remove(orderline2177);
            // await _context.SaveChangesAsync();

            return 1;
        }

        private bool Orderline2177Exists(int id)
        {
            return _context.Orderline2177.Any(e => e.Orderid == id);
        }
    }
}
