namespace Fitsync.Models
{
    public class ExerciseMuscle
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int MuscleId { get; set; }
        public Exercise Exercise { get; set; }
        public Muscle Muscle { get; set; }
    }
}
