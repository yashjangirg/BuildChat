namespace BuildChat.Models
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        //UserRoles
        public Users Creator { get; set; } = new Users();
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
