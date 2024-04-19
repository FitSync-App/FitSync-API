using System.ComponentModel.DataAnnotations.Schema;

namespace Fitsync.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Difficulty { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; } 
    }
}
