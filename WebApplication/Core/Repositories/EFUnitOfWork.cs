using System;
using Faculty.EF;
using Faculty.Entities;
using Faculty.Interfaces;

namespace Faculty.Repositories
{
    
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;
        private Repository<Student> _studentRepository;
        private Repository<FollowingStudent> _followingStudentsRepository;
        private bool _disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            _db = new ApplicationContext();
        }
        
        public IRepository<Student> Students
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new Repository<Student>(_db);
                return _studentRepository;
            } 
        }

        public IRepository<FollowingStudent> FollowingStudent
        {
            get
            {
                if (_followingStudentsRepository == null)
                    _followingStudentsRepository = new Repository<FollowingStudent>(_db);
                return _followingStudentsRepository;
            }
        }
 
        public void Save()
        {
            _db.SaveChanges();
        }
 
        
 
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}