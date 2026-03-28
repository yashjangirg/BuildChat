namespace BuildChat.Models
{
    public class ProjectMembers
    {
        public int UserId { get; set; }
        public Users User { get; set; } = new Users();
        public int ProjectId {get; set; }
        public Projects Project { get; set; } = new Projects();
        public string Role = string.Empty; // e.g., "Developer", "Tester", "Manager"
    }
}
