namespace BuildChat.Models
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedBy { get; set; }

        // Task Relationship
        
        public int TaskId { get; set; }
        public TaskItems TaskItem { get; set; } = new TaskItems();

        // User relationship
    }
}
