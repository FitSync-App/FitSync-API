using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fitsync.Data;
using Fitsync.Models;
using static WorkoutGenerator;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Fitsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly WorkoutGenerator _workoutGenerator;

        public WorkoutController(DatabaseContext context, WorkoutGenerator workoutGenerator)
        {
            _context = context;
            _workoutGenerator = workoutGenerator;

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

        private bool WorkoutExists(int id)
        {
            return (_context.Workout?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //[HttpPost("generate")]
        //public IActionResult GenerateWorkout(string name, MuscleGroup targetMuscleGroup)
        //{
        //    // Validate parameters
        //    if (targetMuscleGroup == null)
        //    {
        //        return BadRequest("Invalid parameters");
        //    }

        //    // Generate workout
        //    var workout = _workoutGenerator.GenerateWorkout(targetMuscleGroup);

        //    foreach(var test in workout)
        //    {
        //        _context.Workout.Add(test);
        //    }

        //    return Ok(workout);
        //}

    }
}
