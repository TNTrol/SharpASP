using System;

namespace DTO
{
    public class SessionMarkDTO
    {
        public int Id { get; set; }
        //public FollowingStudent Student { get; set; }
        public int Mark { get; set; }
        public DateTime With { get; set; }
        public DateTime To { get; set; }
        public string NameCourse { get; set; }
    }
}