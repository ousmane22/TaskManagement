namespace TaskManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? Level { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
