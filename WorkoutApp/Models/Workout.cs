using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutApp.Models
{
    public class Workout
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Difficulty { get; set; }
        public string Equipment { get; set; }
        public string Target_Muscle { get; set; }

        [ForeignKey("UserId")]
        public int User {  get; set; }

    }
}
