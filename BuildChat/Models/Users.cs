namespace BuildChat.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        // User can create multiple Project
        //public List<Projects> Projects { get; set; } = new List<Projects>();
        public ICollection<TaskItems> TaskItems { get; set; } = new List<TaskItems>();

        public ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();

        //rojectMembers relationship

        //public ICollection<ProjectMembers> ProjectMembers { get; set; } = new List<ProjectMembers>();

        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
    }
}

