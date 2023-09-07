namespace TaskManagement.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string? Position { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
