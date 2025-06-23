using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projects.Domain.Entities;
namespace projects.Domain.Entities
{
    public class StudentsInGroups
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public required User Student { get; set; }
        public required Group Group { get; set; }

    }

}