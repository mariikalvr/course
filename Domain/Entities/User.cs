using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projects.Domain.Entities;
namespace projects.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required] // Обязательное поле
        [MaxLength(100)] // Максимальная длина
        public required string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public required Course Courses { get; set; } // Курсы, созданные пользователем
        public required StudentsInGroups StudentGroups { get; set; } // Группы, в которых учится пользователь
        public required Attendances Attendances { get; set; } // Посещения
    }
    public enum UserRole
    {
        Teacher,
        Student
    }

}