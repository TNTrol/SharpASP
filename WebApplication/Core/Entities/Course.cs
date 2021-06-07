using System.Collections.Generic;

namespace Faculty.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public Lecturer Lecturer { get; set; }
        public Subject Subject { get; set; }
        public Semester Semester { get; set; }
        
        public List<FollowingStudent> Students { get; set; }
    }
}