using System.Collections.Generic;
using DTO;

namespace Interfaces
{
    public interface ILecturerService
    {
        IList<CourseLecturerDTO> ShowAllCourses(int idLecturer);

        public bool AddMarkStudent(InputMarkDTO inputMark);

        IList<StudentDTO> ShowAllFollowingStudentsOnCourse(LecturerAndCourseDTO lecturerDto);

        public bool AddNewStudentToCourse(FollowingStudentDTO newStudent);

        public IList<LecturerDTO> ShowAllLecturer();

        public bool AddNewCourse(NewCourseDTO newCourseDto);

        public bool ChangeCourse(UpdateCourseDTO updateCourseDto);

        public void DeleteMark(int id);
        public bool DeleteFollowingStudent(int id);
    }
}