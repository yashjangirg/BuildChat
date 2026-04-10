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
        //public Users Creator { get; set; } = new Users();
        public Users? Creator { get; set; }

        //public Users Users { get; set; } 

        //Tasks relationship
        public ICollection<TaskItems>? TaskItems { get; set; } 

        //ProjectMembers relationship
        public ICollection<ProjectMembers>? ProjectMembers { get; set; } 

    }
}
