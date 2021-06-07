using System;
using System.Collections.Generic;

namespace Faculty.Entities
{
    public class Semester
    {
        public int Id { get; set; }
        public DateTime With { get; set; }
        public DateTime To { get; set; }
        
        public List<Course> Courses { get; set; }
    }
}