namespace TaskManagement.Models
{
    public class TaskUser
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
