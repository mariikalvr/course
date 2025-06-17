using System;

namespace projects.Damain.Entities
{
    public class Lessons
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

    }

}