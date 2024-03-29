﻿namespace IvanRealEstate.Contracts
{
    using System.Linq.Expressions;

    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,bool trackChanges);
        void Create(T entity);
        void Upadate(T entity);
        void Delete(T entity);
    }
}
