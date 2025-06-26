using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using projects.Domain.Entities;
namespace projects.Domain.Entities
{
    public class User : IdentityUser<int>
    {

        [Key]
        public int Id { get; set; }
        [Required] // Обязательное поле
        [MaxLength(100)] // Максимальная длина
        public required string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public Course Courses { get; set; } // Курсы, созданные пользователем
        public StudentsInGroups StudentGroups { get; set; } // Группы, в которых учится пользователь
        public Attendances Attendances { get; set; } // Посещения
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}