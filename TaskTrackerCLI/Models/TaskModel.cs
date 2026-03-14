namespace TaskTrackerCLI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "ToDo";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
