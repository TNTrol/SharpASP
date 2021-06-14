using System;

namespace Model
{
    public class FilterModel
    {
        public string Name { get; set; }
        public int IdSubject { get; set; }
        public DateTime With { get; set; }
        public DateTime To { get; set; }
        public int ExperienceUp { get; set; }
        public int ExperienceDown { get; set; }
        public string OrderBy { get; set; }
    }
}