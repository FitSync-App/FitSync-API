namespace WorkoutApp.Models
{
    public class ExerciseMuscle
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
