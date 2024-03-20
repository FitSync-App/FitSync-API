using System.ComponentModel.DataAnnotations.Schema;
using Fitsync.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fitsync.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int Days {  get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }
    }


public static class WorkoutExerciseEndpoints
{
	public static void MapWorkoutExerciseEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/WorkoutExercise").WithTags(nameof(WorkoutExercise));

        group.MapGet("/", async (DatabaseContext db) =>
        {
            return await db.Workout_Exercise.ToListAsync();
        })
        .WithName("GetAllWorkoutExercises")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<WorkoutExercise>, NotFound>> (int id, DatabaseContext db) =>
        {
            return await db.Workout_Exercise.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is WorkoutExercise model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetWorkoutExerciseById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, WorkoutExercise workoutExercise, DatabaseContext db) =>
        {
            var affected = await db.Workout_Exercise
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, workoutExercise.Id)
                  .SetProperty(m => m.WorkoutId, workoutExercise.WorkoutId)
                  .SetProperty(m => m.ExerciseId, workoutExercise.ExerciseId)
                  .SetProperty(m => m.Days, workoutExercise.Days)
                  .SetProperty(m => m.Sets, workoutExercise.Sets)
                  .SetProperty(m => m.Reps, workoutExercise.Reps)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateWorkoutExercise")
        .WithOpenApi();

        group.MapPost("/", async (WorkoutExercise workoutExercise, DatabaseContext db) =>
        {
            db.Workout_Exercise.Add(workoutExercise);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/WorkoutExercise/{workoutExercise.Id}",workoutExercise);
        })
        .WithName("CreateWorkoutExercise")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, DatabaseContext db) =>
        {
            var affected = await db.Workout_Exercise
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteWorkoutExercise")
        .WithOpenApi();
    }
}}
