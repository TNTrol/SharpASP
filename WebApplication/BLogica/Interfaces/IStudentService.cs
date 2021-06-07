

using System.Collections.Generic;
using DTO;
using Faculty.Entities;

namespace Interfaces
{
    public interface IStudentService
    {
        IList<MarkDTO> ShowMarksCourseByIdStudent(FollowStudentDTO followStudent);

        IList<SessionMarkDTO> ShowSessionMarksIdStudent(int idStudent);

        IList<CourseDTO> ShowAllCoursesOfStudent(int idStudent);

        IList<StudentDTO> ShowAllStudents();
    }
}