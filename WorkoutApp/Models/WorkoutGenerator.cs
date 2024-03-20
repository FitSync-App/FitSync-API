using System;
using System.Collections.Generic;
using System.Linq;
using Fitsync.Data;
using Fitsync.Models;

public class WorkoutGenerator
{
    private DatabaseContext _dbContext; 

    public WorkoutGenerator(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public enum MuscleGroup
    {
        Chest = 1,
        Arms = 2,
        Legs = 3,
        Back = 4,
        Shoulders = 5,
        Core = 6,
    }

    public enum Difficulty
    {
        Beginner = 0,
        Intermediate = 3,
        Advanced = 5
    }

    public enum Equipment
    {
    }

    public List<Exercise> GenerateWorkout(MuscleGroup targetMuscleGroup)
    {
        List<Exercise> workoutExercises = new List<Exercise>();

        Exercise exercise = GetRandomExercise(targetMuscleGroup);
        workoutExercises.Add(exercise);

        return workoutExercises;
    }


    private Exercise GetRandomExercise(MuscleGroup muscleGroup)
    {
        // Fetch exercises from the database based on muscle group
        List<Exercise> exercises = _dbContext.Exercise
                                            .Where(e => e.MuscleId == (int)muscleGroup)
                                            .ToList();

        // Get a random exercise
        Random rand = new Random();
        int randomIndex = rand.Next(exercises.Count);
        return exercises[randomIndex];
    }

}
