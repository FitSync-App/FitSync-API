namespace WorkoutApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public Equipment Equipment { get; set; }
        public Muscle Muscle { get; set; }
    }
}
