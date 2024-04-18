namespace Fitsync.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string? Description { get; set; }
        public int? EquipmentId { get; set; }
        public int MuscleId { get; set; }
        
        public string? Type { get; set; }
    }

}