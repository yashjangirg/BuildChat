namespace BuildChat.Models
{
    public class TaskAssignment
    {
        public int UserId { get; set; }
        public Users User { get; set; } = new Users();
        public int TaskItemId { get; set; }
        public TaskItems TaskItems { get; set; } = new TaskItems();
        
        public DateTime JoinedOn { get; set; } = DateTime.Now;
    }
}
