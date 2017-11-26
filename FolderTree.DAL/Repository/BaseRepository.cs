using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTree.DAL.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected FolderTreeEntities dbContext;

        public BaseRepository()
        {
            dbContext = new FolderTreeEntities();
        }

        public BaseRepository(FolderTreeEntities context)
        {
            dbContext = context;
        }

        public abstract DbSet<T> GetEntities();

        public abstract T GetEntity(int id);

        public abstract int Create(T item);

        public abstract bool CreateRange(List<T> listEntities);

        public abstract bool Update(T item);

        public abstract bool Delete(int id);

        public abstract bool DeleteRange(List<T> listEntities);

        public abstract bool UpdateRange(List<T> listEntities);

        #region Dispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
