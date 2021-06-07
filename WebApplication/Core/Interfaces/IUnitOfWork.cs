using System;
using Faculty.Entities;

namespace Faculty.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get;}
        IRepository<FollowingStudent> FollowingStudent { get;}
        void Save();
    }
}