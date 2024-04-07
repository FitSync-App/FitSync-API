using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fitsync.Data;
using Fitsync.Models;

namespace Fitsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutExercisesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WorkoutExercisesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutExercise>>> GetWorkout_Exercise()
        {
            if (_context.Workout_Exercise == null)
            {
                return NotFound();
            }

            return await _context.Workout_Exercise.ToListAsync();
        }

        // GET: api/WorkoutExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutExercise>> GetWorkoutExercise(int id)
        {
            if (_context.Workout_Exercise == null)
            {
                return NotFound();
            }

            var workoutExercise = await _context.Workout_Exercise.FindAsync(id);

            if (workoutExercise == null)
            {
                return NotFound();
            }

            return workoutExercise;
        }

        // PUT: api/WorkoutExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutExercise(int id, WorkoutExercise workoutExercise)
        {
            if (id != workoutExercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExerciseExists(id))
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

        // POST: api/WorkoutExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutExercise>> PostWorkoutExercise(WorkoutExercise workoutExercise)
        {
            if (_context.Workout_Exercise == null)
            {
                return Problem("Entity set 'DatabaseContext.Workout_Exercise'  is null.");
            }

            _context.Workout_Exercise.Add(workoutExercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutExercise", new { id = workoutExercise.Id }, workoutExercise);
        }

        // DELETE: api/WorkoutExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutExercise(int id)
        {
            if (_context.Workout_Exercise == null)
            {
                return NotFound();
            }

            var workoutExercise = await _context.Workout_Exercise.FindAsync(id);
            if (workoutExercise == null)
            {
                return NotFound();
            }

            _context.Workout_Exercise.Remove(workoutExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExerciseExists(int id)
        {
            return (_context.Workout_Exercise?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("GetExercisesByWorkoutId")]
        public List<Exercise> GetExercisesByWorkoutId(int workoutId)
        {
            return _context.Workout_Exercise
                .Where(we => we.WorkoutId == workoutId)
                .Select(we => we.Exercise)
                .ToList();
        }

        [HttpGet("GetWorkoutsByUserId")]
        public ActionResult<IEnumerable<WorkoutExercise>> GetWorkoutsByUserId(string userId)
        {
            var workoutExercises = _context.Workout_Exercise
                .Include(we => we.Workout) // Include the Workout entity
                .Where(we => we.Workout.UserId == userId)
                .Select(we => new 
                {
                    WorkoutName = we.Workout.Name, 
                    ExerciseName = we.Exercise.Name,
                    ExerciseDifficulty = we.Exercise.Difficulty,
                    ExerciseDescription = we.Exercise.Description,
                    Equipment = _context.Equipment
                        .Where(e => e.Id == we.Exercise.EquipmentId)
                        .Select(e => e.Name)
                        .FirstOrDefault(), 
                    MuscleName = _context.Muscle
                        .Where(m => m.Id == we.Exercise.MuscleId)
                        .Select(m => m.Name)
                        .FirstOrDefault() 
                })
                .ToList();

            if (workoutExercises == null || workoutExercises.Count == 0)
            {
                return NotFound("No workouts found for the specified user.");
            }

            return Ok(workoutExercises);
        }
    }
}
