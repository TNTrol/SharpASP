using System;

namespace Faculty.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public FollowingStudent Student { get; set; }
        public int MarkStudent { get; set; }
        public DateTime Date { get; set; }
    }
}