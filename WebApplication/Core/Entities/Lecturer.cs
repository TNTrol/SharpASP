using System;
using System.Collections.Generic;

namespace Faculty.Entities
{
    public class Lecturer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Experience { get; set; }

        public List<Course> Courses { get; set; }
    }
}