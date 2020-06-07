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
    public class Authorisedperson2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Authorisedperson2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Authorisedperson2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authorisedperson2177>>> GetAuthorisedperson2177()
        {
            return await _context.Authorisedperson2177.ToListAsync();
        }

        // GET: api/Authorisedperson2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authorisedperson2177>> GetAuthorisedperson2177(int id)
        {
            var authorisedperson2177 = await _context.Authorisedperson2177.FindAsync(id);

            if (authorisedperson2177 == null)
            {
                return NotFound();
            }

            return authorisedperson2177;
        }

        // PUT: api/Authorisedperson2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorisedperson2177(int id, Authorisedperson2177 authorisedperson2177)
        {
            if (id != authorisedperson2177.Userid)
            {
                return BadRequest();
            }

            _context.Entry(authorisedperson2177).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Authorisedperson2177Exists(id))
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

        // POST: api/Authorisedperson2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Authorisedperson2177>> PostAuthorisedperson2177(Authorisedperson2177 ap)
        {
            // _context.Authorisedperson2177.Add(authorisedperson2177);


            var authorisedPersonAccountID = await Task.FromResult(_context.Authorisedperson2177.FromSqlRaw("EXEC ADD_AUTHORISED_PERSON " +
                "@PFIRSTNAME = " + ap.Firstname + 
                ", @PSURNAME = " + ap.Surname + 
                ", @PEMAIL = " + ap.Email + 
                ", @PPASSWORD = " + ap.Password + 
                ", @PACCOUNTID = " + ap.Accountid).ToList());

            // await _context.SaveChangesAsync();

            return authorisedPersonAccountID[0];
        }

        // DELETE: api/Authorisedperson2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Authorisedperson2177>> DeleteAuthorisedperson2177(int id)
        {
            var authorisedperson2177 = await _context.Authorisedperson2177.FindAsync(id);
            if (authorisedperson2177 == null)
            {
                return NotFound();
            }

            _context.Authorisedperson2177.Remove(authorisedperson2177);
            await _context.SaveChangesAsync();

            return authorisedperson2177;
        }

        private bool Authorisedperson2177Exists(int id)
        {
            return _context.Authorisedperson2177.Any(e => e.Userid == id);
        }
    }
}
