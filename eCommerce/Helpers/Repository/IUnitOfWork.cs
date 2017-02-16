using System;

namespace eCommerce.Helpers.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
