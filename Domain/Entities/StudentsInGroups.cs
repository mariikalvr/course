using System;

namespace projects.Damain.Entities
{
    public class StudentsInGroups
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public User Student { get; set; }
        public Group Group { get; set; }

    }

}