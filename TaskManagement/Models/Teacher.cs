﻿namespace TaskManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? TaughtSubject { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
