using System;
using FolderTree.DAL.Repository;

namespace FolderTree.DAL.Provider
{
    public interface IRepositoryProvider : IDisposable
    {
        IRepository<tbl_TreeNode> TreeNodeRepository { get; }
    }
}