using System.Collections.Generic;
using DTO;

namespace Interfaces
{
    public interface ILecturerService
    {
        IList<CourseDTO> ShowAllCourses(int idLecturer);

        public bool AddMarkStudent(InputMarkDTO inputMark);

        IList<StudentDTO> ShowAllFollowingStudentsOnCourse(LecturerDTO lecturerDto);

        public bool AddNewStudentToCourse(FollowingStudentDTO newStudent);

        public IList<LecturerDTO> ShowAllLecturer();
    }
}