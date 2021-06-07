using System;
using System.Collections.Generic;

namespace Faculty.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public String Name { get; set; }
        
        public List<Course> Courses { get; set; }
    }
}