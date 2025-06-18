using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projects.Domain.Entities;
namespace projects.Domain.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public int CourseId { get; set; }
        public required List<Course> Course { get; set; }
        public ICollection<StudentsInGroups> Students { get; set; } // Студенты в группе
        public ICollection<Lesson> Lessons { get; set; } // Уроки в группе
    }

}