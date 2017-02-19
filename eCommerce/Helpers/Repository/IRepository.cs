using eCommerce.Helpers.Domain;
using eCommerce.Helpers.Specification;
using System;
using System.Collections.Generic;

namespace eCommerce.Helpers.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);

        TEntity FindOne(ISpecification<TEntity> spec);

        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}