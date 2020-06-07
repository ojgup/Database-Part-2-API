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
    public class Clientaccount2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;
        
        public Clientaccount2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Clientaccount2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientaccount2177>>> GetClientaccount2177()
        {
            return await _context.Clientaccount2177.ToListAsync();
        }

        // GET: api/Clientaccount2177/5
        [HttpGet("{id}")]
        public async Task<List<Clientauthorisedaccounts2177>> GetClientaccount2177(int id)
        {
            // var clientaccount2177 = await _context.Clientaccount2177.FindAsync(id);

            // var account = await Task.FromResult(_context.Clientaccount2177.Include(x => x.Authorisedperson2177).ToList());

            var account = await Task.FromResult(_context.Clientauthorisedaccounts2177.FromSqlRaw("EXEC GET_CLIENT_ACCOUNT_BY_ID @PACCOUNTID = " + id).ToList());

            /*
            if (account == null)
            {   
                return NotFound();
            }
            */

            return account;
        }

        // PUT: api/Clientaccount2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientaccount2177(int id, Clientaccount2177 clientaccount2177)
        {
            if (id != clientaccount2177.Accountid)
            {
                return BadRequest();
            }

            _context.Entry(clientaccount2177).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Clientaccount2177Exists(id))
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

        // POST: api/Clientaccount2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clientaccount2177>> PostClientaccount2177(Clientaccount2177 c)
        {
            // _context.Clientaccount2177.Add(clientaccount2177);

 
            var accountID = await Task.FromResult(_context.Clientaccount2177.FromSqlRaw("EXEC ADD_CLIENT_ACCOUNT @PACCTNAME = " + c.Acctname + 
                ", @PBALANCE = " + c.Balance + 
                ", @PCREDITLIMIT = " + c.Creditlimit).ToList());

            // await _context.SaveChangesAsync();
            return accountID[0];
        }

        // DELETE: api/Clientaccount2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientaccount2177>> DeleteClientaccount2177(int id)
        {
            var clientaccount2177 = await _context.Clientaccount2177.FindAsync(id);
            if (clientaccount2177 == null)
            {
                return NotFound();
            }

            _context.Clientaccount2177.Remove(clientaccount2177);
            await _context.SaveChangesAsync();

            return clientaccount2177;
        }

        private bool Clientaccount2177Exists(int id)
        {
            return _context.Clientaccount2177.Any(e => e.Accountid == id);
        }
    }
}
