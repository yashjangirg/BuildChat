namespace BuildChat.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public Roles Roles { get; set; } 

        public int UserId { get; set; }
        public Users? Users { get; set; }
    }
}
