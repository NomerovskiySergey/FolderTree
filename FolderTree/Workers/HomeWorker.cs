using System;
using System.Collections.Generic;
using System.Linq;
using FolderTree.Core.Entities;
using FolderTree.DAL.Provider;

namespace FolderTree.Core.Workers
{
    public class HomeWorker : IDisposable
    {
        #region Constructors

        public HomeWorker()
        {
            _provider = new RepositoryProvider();
        }

        public HomeWorker(IRepositoryProvider provider)
        {
            _provider = provider;
        }
        #endregion

        private IRepositoryProvider _provider;

        public List<RouteEntity> GetCollectionByParentId(int? parentId)
        {
            return _provider.TreeNodeRepository.GetEntities()
                .Where(p => p.ParentId == parentId)
                .Select(s => new RouteEntity()
                {
                    Name = s.Name,
                    Url = s.Url

                }).ToList();
        }

        public string GetParentFolderName(int? parentId)
        {

            return _provider.TreeNodeRepository.GetEntities()
                .FirstOrDefault(p => p.ParentId == parentId)?.Name;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _provider.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
