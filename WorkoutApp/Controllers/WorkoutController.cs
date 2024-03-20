using System;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
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
