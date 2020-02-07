using System;

namespace CadSage.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        string Commit();
    }
}