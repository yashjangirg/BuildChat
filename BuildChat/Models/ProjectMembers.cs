namespace BuildChat.Models
{
    public class ProjectMembers
    {
        public int UserId { get; set; }
        public Users Users { get; set; } = new Users();
        public int ProjectId {get; set; }
        public Projects Projects { get; set; } = new Projects();
        public string Role { get; set; } = string.Empty; // e.g., "Developer", "Tester", "Manager"
        public DateTime JoinedOn { get; set; } = DateTime.Now;
    }
}
