namespace BuildChat.Models
{
    public class TaskAssignment
    {
        public int UserId { get; set; }
        public Users? Users { get; set; } 
        public int TaskItemId { get; set; }
        public TaskItems? TaskItems { get; set; } 
        
        public DateTime JoinedOn { get; set; } = DateTime.Now;
    }
}
