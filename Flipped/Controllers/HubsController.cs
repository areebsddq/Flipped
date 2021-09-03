using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HubService.Database;
using HubService.Database.Entitties;

namespace HubService.Controllers
{
    [Route("api/hub")]
    [ApiController]
    public class HubsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HubsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hub>>> GetHubs()
        {
            return await _context.Hubs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hub>> GetHub(int id)
        {
            var hub = await _context.Hubs.FindAsync(id);

            if (hub == null)
            {
                return NotFound();
            }

            return hub;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHub(int id, Hub hub)
        {
            if (id != hub.Id)
            {
                return BadRequest();
            }

            _context.Entry(hub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Hub>> PostHub(Hub hub)
        {
            _context.Hubs.Add(hub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHub", new { id = hub.Id }, hub);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHub(int id)
        {
            var hub = await _context.Hubs.FindAsync(id);
            if (hub == null)
            {
                return NotFound();
            }

            _context.Hubs.Remove(hub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HubExists(int id)
        {
            return _context.Hubs.Any(e => e.Id == id);
        }
    }
}
