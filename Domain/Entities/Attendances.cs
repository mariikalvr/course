using System;

namespace projects.Damain.Entities
{
    public class Attendances
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public bool IsPresent { get; set; }
        public Lesson Lesson { get; set; }
        public User Student { get; set; }

    }

}

    