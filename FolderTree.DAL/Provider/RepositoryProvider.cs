using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderTree.DAL.Repository;

namespace FolderTree.DAL.Provider
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private FolderTreeEntities dbContext;

        public RepositoryProvider()
        {
            dbContext = new FolderTreeEntities();
        }

        private IRepository<tbl_TreeNode> _treeNodeRepository;

        public IRepository<tbl_TreeNode> TreeNodeRepository
        {
            get
            {
                if (_treeNodeRepository == null)
                {
                    _treeNodeRepository = new TreeNodeRepository(dbContext);
                }

                return _treeNodeRepository;
            }
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            _treeNodeRepository?.Dispose();
        }
    }
}
