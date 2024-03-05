﻿namespace WorkoutApp.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int Days {  get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
