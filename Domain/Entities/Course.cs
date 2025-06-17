using System;

namespace projects.Damain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

    }

}