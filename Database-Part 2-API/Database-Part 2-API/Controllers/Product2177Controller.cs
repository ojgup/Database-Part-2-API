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
    public class Product2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Product2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Product2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product2177>>> GetProduct2177()
        {
            return await _context.Product2177.ToListAsync();
        }

        // GET: api/Product2177/5
        [HttpGet("{id}")] 
        public async Task<ActionResult<Product2177>> GetProduct2177(int id)
        {
            // var product2177 = await _context.Product2177.FindAsync(id);

            var product = await Task.FromResult(_context.Product2177.FromSqlRaw("EXEC GET_PRODUCT_BY_ID " +
                "@PPRODID = " + id).ToList());
            
            if (product == null)
            {
                return NotFound();
            }

            return product[0];
        }

        // PUT: api/Product2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct2177(int id, Product2177 product2177)
        {
            if (id != product2177.Productid)
            {
                return BadRequest();
            }

            _context.Entry(product2177).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product2177Exists(id))
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

        // POST: api/Product2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product2177>> PostProduct2177(Product2177 p)
        {
            // _context.Product2177.Add(product2177);
            
            _context.Database.ExecuteSqlRaw("EXEC ADD_PRODUCT @PPRODNAME = " + p.Prodname + 
                ", @PBUYPRICE = " + p.Buyprice + 
                ", @PSELLPRICE = " + p.Sellprice);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct2177", new { id = p.Prodname }, p);
        }

        // DELETE: api/Product2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product2177>> DeleteProduct2177(int id)
        {
            var product2177 = await _context.Product2177.FindAsync(id);
            if (product2177 == null)
            {
                return NotFound();
            }

            _context.Product2177.Remove(product2177);
            await _context.SaveChangesAsync();

            return product2177;
        }

        private bool Product2177Exists(int id)
        {
            return _context.Product2177.Any(e => e.Productid == id);
        }
    }
}
