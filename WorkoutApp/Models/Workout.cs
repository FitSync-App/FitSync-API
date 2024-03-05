using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutApp.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Difficulty { get; set; }
        public string Equipment { get; set; }
        public string Target_Muscle { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } 
    }
}
