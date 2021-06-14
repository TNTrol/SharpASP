using System;

namespace DTO
{
    public class FullCourseDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime With { get; set; }
        
        public int IdSubject { get; set; }
        public DateTime To { get; set; }
        public string Lecturer { get; set; }
        
        public int Experience { get; set; }
    }
}