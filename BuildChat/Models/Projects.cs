namespace BuildChat.Models
{
    public class Projects
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
       
        // User can Create Project
        //OwnerShip k liy

        public int CreatorId { get; set; }
        public Users Creator { get; set; } = new Users();

        //public Users Users { get; set; } 

    }
}
