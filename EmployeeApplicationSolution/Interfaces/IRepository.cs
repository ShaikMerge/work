﻿namespace EmployeeApplicationSolution.Interfaces
{
    public interface IRepository<T, K> where T : class
    {

        T Add(T entity);
        ICollection<T> Get();
        T Get(K key);
        T Update(K key, T entity);
        T Delete(K key);


    }
}
