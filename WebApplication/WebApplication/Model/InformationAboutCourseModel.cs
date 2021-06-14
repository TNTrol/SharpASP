using System;

namespace Model
{
    public class InformationAboutCourseModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime With { get; set; }
        public DateTime To { get; set; }
        public string Lecturer { get; set; }
    }
}