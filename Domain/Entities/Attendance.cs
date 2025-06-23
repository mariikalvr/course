using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projects.Domain.Entities;
namespace projects.Domain.Entities
{
    public class Attendances
    {
        [Key]
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public bool IsPresent { get; set; }
        public required Lesson Lesson { get; set; }
        public required User Student { get; set; }

    }

}

    