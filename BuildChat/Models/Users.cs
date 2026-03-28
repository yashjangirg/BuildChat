namespace BuildChat.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        // User can create multiple Project
        public List<Projects> Projects { get; set; } = new List<Projects>();
        //public ICollection<Projects> Projects { get; set; } = new List<Projects>();
    }
}
}
