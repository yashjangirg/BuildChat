namespace BuildChat.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        // User can create multiple Project
        public List<Projects>? Projects { get; set; }
        public ICollection<TaskItems>? TaskItems { get; set; } 

        public ICollection<TaskAssignment>? TaskAssignments { get; set; }

        //ProjectMembers relationship/ Task Assignment relationship k liy

        public ICollection<ProjectMembers>? ProjectMembers { get; set; }

        //Comments relationship k liy
        public ICollection<Comments>? Comments { get; set; }

        //User can Create multiple TaskItems
        public ICollection<UserRole>? UserRoles { get; set; }
        
    }
}

