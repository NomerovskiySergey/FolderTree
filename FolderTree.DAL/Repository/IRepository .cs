using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace FolderTree.DAL.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        DbSet<T> GetEntities();
        T GetEntity(int id); 
        int Create(T item);
        bool CreateRange(List<T> listEntities);
        bool Update(T item);
        bool UpdateRange(List<T> listEntities);
        bool Delete(int id);
        bool DeleteRange(List<T> listEntities);

    }
}