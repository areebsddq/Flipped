using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HubService.Database;
using HubService.Database.Entitties;
using System.Collections.Generic;

namespace HubService.Controllers
{
    [Route("api/hub")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LessonsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{hubId}/lessons")]
        public IEnumerable<Lesson> GetLessons(int hubId)
        {
            return _context.Lessons.Where(l => l.HubId == hubId);
        }

        [HttpGet("lesson/{id}")]
        public Lesson GetLesson(int id)
        {
            return _context.Lessons.FirstOrDefault(l => l.Id == id);
        }

        [HttpPut("lesson/{id}")]
        public async Task<IActionResult> PutLesson(int id, [FromBody] Lesson lesson)
        {
            if (id != lesson.Id || !LessonExists(id))
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        [HttpPost("lesson")]
        public async Task<ActionResult<Lesson>> PostLesson(Lesson lesson)
        {
            if (!HubExists(lesson.HubId))
            {
                return BadRequest();
            }

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = lesson.Id }, lesson);
        }

        [HttpDelete("lesson/{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }

        private bool HubExists(int id)
        {
            return _context.Hubs.Any(e => e.Id == id);
        }
    }
}
