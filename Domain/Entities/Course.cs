
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projects.Domain.Entities;
namespace projects.Domain.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int CreatedById { get; set; }
        public required List<User> CreatedBy { get; set; }
        public required ICollection<Group> Groups { get; set; } // Группы, связанные с курсом

    }

}