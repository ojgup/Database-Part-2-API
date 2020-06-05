using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_Part_2_API.Models;
using System.Data.SqlClient;

namespace Database_Part_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Location2177Controller : ControllerBase
    {
        private readonly _102542177Context _context;

        public Location2177Controller(_102542177Context context)
        {
            _context = context;
        }

        // GET: api/Location2177
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location2177>>> GetLocation2177()
        {
            return await _context.Location2177.ToListAsync();
        }

        // GET: api/Location2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location2177>> GetLocation2177(string id)
        {
            var location = await Task.FromResult(_context.Location2177.FromSqlRaw("EXEC GET_LOCATION_BY_ID " +
                "@PLOCID = " + id).ToList());


            if (location == null)
            {
                return NotFound();
            }

            // return Task.FromResult<Location2177>(new List<Location2177>() { location });
            return location[0];
        }

        // PUT: api/Location2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation2177(string id, Location2177 l)
        {
            if (id != l.Locationid)
            {
                return BadRequest();
            }

            // _context.Entry(location2177).State = EntityState.Modified;

            try
            {



                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Location2177Exists(id))
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

        // POST: api/Location2177
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Location2177>> PostLocation2177(Location2177 l)
        {
            // _context.Location2177.Add(location2177);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC ADD_LOCATION @PLOCID = " + l.Locationid + 
                    ", @PLOCNAME = " + l.Locname + 
                    ", @PLOCADDRESS = " + l.Address +  
                    ", @PMANAGER = " + l.Manager );

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Location2177Exists(l.Locationid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocation2177", new { id = l.Locationid }, l);
        }

        // DELETE: api/Location2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Location2177>> DeleteLocation2177(string id)
        {
            var location2177 = await _context.Location2177.FindAsync(id);
            if (location2177 == null)
            {
                return NotFound();
            }

            _context.Location2177.Remove(location2177);
            await _context.SaveChangesAsync();

            return location2177;
        }

        private bool Location2177Exists(string id)
        {
            return _context.Location2177.Any(e => e.Locationid == id);
        }
    }
}
