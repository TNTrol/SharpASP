

using System;
using System.Collections.Generic;
using System.Linq;
using Faculty.Entities;
using Faculty.Interfaces;
using Faculty.Repositories;
using Interfaces;

namespace Services
{
    public class AdminService : IAdminService
    {
        private IRepository<Student> _studentRepository;
        private IRepository<Lecturer> _lecturerRepository;
        private IRepository<Subject> _subjectRepository;
        private IRepository<Semester> _semesterRepository;

        public AdminService(IRepository<Student> studentRepository, IRepository<Lecturer> lecturerRepository, IRepository<Subject> subjectRepository, IRepository<Semester> semesterRepository)
        {
            _lecturerRepository = lecturerRepository;
            _semesterRepository = semesterRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        public void AddNewLecturer(String name, int experience)
        {
            Lecturer lecturer = new Lecturer() {Name = name, Courses = new List<Course>(), Experience = experience};
            _lecturerRepository.Create(lecturer);
        }

        public void AddNewStudent(String name)
        {
            Student student = new Student() {Name = name, FollowingStudents = new List<FollowingStudent>()};
            _studentRepository.Create(student);
        }

        public void AddNewSubject(String name)
        {
            Subject subject = new Subject() {Name = name, Courses = new List<Course>()};
            _subjectRepository.Create(subject);
        }

        public void AddNewSemester(DateTime with, DateTime to)
        {
            Semester semester = new Semester() {With = with, To = to, Courses = new List<Course>()};
            _semesterRepository.Create(semester);
        }

        public IList<Lecturer> ShowAllLecturers()
        {
            return _lecturerRepository.GetAll().ToList();
        }

        public bool ChangeLecturerById(int id, String name, int experience)
        {
            Lecturer lecturer = _lecturerRepository.Get(id);
            if (lecturer == null)
                return false;
            lecturer.Name = name;
            lecturer.Experience = experience;
            _lecturerRepository.Update(lecturer);
            return true;
        }

        public IList<Student> ShowAllStudents()
        {
            return _studentRepository.GetAll().ToList();
        }

        public bool ChangeStudentById(int id, String name)
        {
            Student student = _studentRepository.Get(id);
            if (student == null)
                return false;
            student.Name = name;
            _studentRepository.Update(student);
            return true;
        }
    }
}