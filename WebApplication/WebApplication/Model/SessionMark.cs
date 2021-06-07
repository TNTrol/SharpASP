using System;

namespace Model
{
    public class SessionMarkModel
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public DateTime With { get; set; }
        public DateTime To { get; set; }
        public string NameCourse { get; set; }
    }
}