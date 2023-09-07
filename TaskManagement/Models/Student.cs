namespace TaskManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? Grade { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
