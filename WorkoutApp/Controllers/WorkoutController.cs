using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fitsync.Data;
using Fitsync.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Fitsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WorkoutController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Workout
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkout()
        {
          if (_context.Workout == null)
          {
              return NotFound();
          } 
          return await _context.Workout.ToListAsync();
        }

        // GET: api/Workout/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
          if (_context.Workout == null)
          {
              return NotFound();
          } 
          var workout = await _context.Workout.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<int>> GetWorkoutIdByName(string name)
        {
            try
            {
                var workoutId = await _context.Workout
                    .Where(w => w.Name == name)
                    .Select(w => w.Id)
                    .FirstOrDefaultAsync();

                if (workoutId == 0)
                {
                    return NotFound();
                }

                return workoutId;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        // PUT: api/Workout/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("UpdateWorkout")]
        public async Task<IActionResult> UpdateWorkout(int id, string newName, string newDescription, string newDuration, string newDifficulty, string newUserId)
        {
            try
            {
                var workoutToUpdate = await _context.Workout.FirstOrDefaultAsync(w => w.Id == id);

                if (workoutToUpdate == null)
                {
                    return NotFound();
                }

                workoutToUpdate.Name = newName;
                workoutToUpdate.Description = newDescription;
                workoutToUpdate.Duration = newDuration;
                workoutToUpdate.Difficulty = newDifficulty;
                workoutToUpdate.UserId = newUserId;

                _context.Update(workoutToUpdate);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the workout.");
            }
        }

        // POST: api/Workout
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
          if (_context.Workout == null)
          {
              return Problem("Entity set 'DatabaseContext.Workout'  is null.");
          } 
          _context.Workout.Add(workout); 
          await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout", new { id = workout.Id }, workout);
        }

        // DELETE: api/Workout/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            if (_context.Workout == null)
            {
                return NotFound();
            }
            var workout = await _context.Workout.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workout.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
