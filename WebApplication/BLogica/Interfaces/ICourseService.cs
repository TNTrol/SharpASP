using System.Collections.Generic;
using DTO;

namespace Interfaces
{
    public interface ICourseService
    {
        public IList<FullCourseDTO> ShowCourses();
    }
}