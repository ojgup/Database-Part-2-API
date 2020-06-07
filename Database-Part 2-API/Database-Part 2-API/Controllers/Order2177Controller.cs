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
    public class Order2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Order2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Order2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order2177>>> GetOrder2177()
        {
            var openOrders = await Task.FromResult(_context.Order2177.FromSqlRaw("EXEC GET_OPEN_ORDERS").ToList());

            return openOrders;
        }

        // GET: api/Order2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order2177>> GetOrder2177(int id)
        {
            // var order2177 = await _context.Order2177.FindAsync(id);


            var orderID = await Task.FromResult(_context.Order2177.FromSqlRaw("EXEC GET_ORDER_BY_ID " +
                "@PORDERID = " + id).ToList());

            if (orderID == null)
            {
                return NotFound();
            }

            return orderID[0];
        }

        // PUT: api/Order2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder2177(int id, Order2177 order2177)
        {
            if (id != order2177.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(order2177).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order2177Exists(id))
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

        // POST: api/Order2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order2177>> PostOrder2177(Order2177 o)
        {
           //  _context.Order2177.Add(o);

            var orderID = await Task.FromResult(_context.Order2177.FromSqlRaw("EXEC CREATE_ORDER " +
               "@PSHIPPINGADDRESS = " + o.Shippingaddress + 
               ", @PUSERID = " + o.Userid ).ToList());

            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetOrder2177", new { id = o.Orderid }, o);

            return orderID[0];
        }

        // DELETE: api/Order2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order2177>> DeleteOrder2177(int id)
        {
            var order2177 = await _context.Order2177.FindAsync(id);
            if (order2177 == null)
            {
                return NotFound();
            }

            _context.Order2177.Remove(order2177);
            await _context.SaveChangesAsync();

            return order2177;
        }

        private bool Order2177Exists(int id)
        {
            return _context.Order2177.Any(e => e.Orderid == id);
        }
    }
}
