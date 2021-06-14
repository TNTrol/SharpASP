using System;
using System.Collections.Generic;
using DTO;
using Faculty.Entities;

namespace Interfaces
{
    public interface IAdminService
    {
        void AddNewLecturer(String name, int experience);
        void AddNewStudent(String name);

        void AddNewSubject(String name);
        void AddNewSemester(DateTime with, DateTime to);

        IList<Lecturer> ShowAllLecturers();

        bool ChangeLecturerById(int id, String name, int experience);

        IList<Student> ShowAllStudents();

        bool ChangeStudentById(int id, String name);
        public IList<SubjectDTO> ShowAllSubjects();
        public IList<SemesterDTO> ShowAllSemesters();
        public bool ChangeSubject(SubjectDTO s);

        public bool ChangeSemester(SemesterDTO semesterDto);
    }
}