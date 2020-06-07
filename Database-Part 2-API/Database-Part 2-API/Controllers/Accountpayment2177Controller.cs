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
    public class Accountpayment2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Accountpayment2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Accountpayment2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountpayment2177>>> GetAccountpayment2177()
        {
            return await _context.Accountpayment2177.ToListAsync();
        }

        // GET: api/Accountpayment2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accountpayment2177>> GetAccountpayment2177(int id)
        {
            var accountpayment2177 = await _context.Accountpayment2177.FindAsync(id);

            if (accountpayment2177 == null)
            {
                return NotFound();
            }

            return accountpayment2177;
        }

        // PUT: api/Accountpayment2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountpayment2177(int id, Accountpayment2177 accountpayment2177)
        {
            if (id != accountpayment2177.Accountid)
            {
                return BadRequest();
            }

            _context.Entry(accountpayment2177).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Accountpayment2177Exists(id))
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

        // POST: api/Accountpayment2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Accountpayment2177>> PostAccountpayment2177(Accountpayment2177 ap)
        {
  //          _context.Accountpayment2177.Add(ap);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC MAKE_ACCOUNT_PAYMENT " +
                    "@PACCOUNTID = " + ap.Accountid +
                    ", @PAMOUNT = " + ap.Amount);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Accountpayment2177Exists(ap.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountpayment2177", new { id = ap.Accountid }, ap);
        }

        // DELETE: api/Accountpayment2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Accountpayment2177>> DeleteAccountpayment2177(int id)
        {
            var accountpayment2177 = await _context.Accountpayment2177.FindAsync(id);
            if (accountpayment2177 == null)
            {
                return NotFound();
            }

            _context.Accountpayment2177.Remove(accountpayment2177);
            await _context.SaveChangesAsync();

            return accountpayment2177;
        }

        private bool Accountpayment2177Exists(int id)
        {
            return _context.Accountpayment2177.Any(e => e.Accountid == id);
        }
    }
}
