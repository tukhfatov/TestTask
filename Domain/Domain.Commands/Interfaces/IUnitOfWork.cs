using System;

namespace Domain.Commands.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}