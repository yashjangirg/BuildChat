namespace BuildChat.Models
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedBy { get; set; }

        // Task Relationship
        
        public int TaskItemId { get; set; }
        public TaskItems? TaskItems { get; set; } 

        // User relationship
        public int UserId { get; set; }
        public Users? Users { get; set; }
    }
}
