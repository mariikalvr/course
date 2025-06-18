using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projects.Domain.Entities;
namespace projects.Domain.Entities

{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public required string Topic { get; set; }
        public int GroupId { get; set; }
        public required Group Group { get; set; }

    }

}