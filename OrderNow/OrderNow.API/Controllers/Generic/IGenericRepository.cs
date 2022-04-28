﻿namespace OrderNow.API.Controllers.Generic
{
        public interface IGenericRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAll();

        Task<T> GetByIdAsync(string Id);
        Task<T> GetByNameAsync(string Name);

        bool Delete(T entity);

        Task<bool> CreateAsync(T entity);

        Task<bool> EditAsync(T entity);
        Task<int> SaveAsync();
        
    }
}
