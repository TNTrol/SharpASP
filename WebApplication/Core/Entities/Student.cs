using System;
using System.Collections;
using System.Collections.Generic;

namespace Faculty.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public List<FollowingStudent> FollowingStudents { get; set; }
    }
}