namespace BuildChat.Models
{
    public class TaskItems
    {
        public int TaskItemId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;


        //OwnerShip k liy

        public int CreatorId { get; set; }
        public Users Creator { get; set; } = new Users();


        //Project k sath relation k liy
         public int ProjectId { get; set; }

       
        public Projects Project { get; set; } = new Projects();
    }
}
