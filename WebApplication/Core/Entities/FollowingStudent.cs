using System.Collections.Generic;

namespace Faculty.Entities
{
    public class FollowingStudent
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        public List<Mark> Marks { get; set; }
        public SessionMark SessionMarks { get; set; }
    }
}