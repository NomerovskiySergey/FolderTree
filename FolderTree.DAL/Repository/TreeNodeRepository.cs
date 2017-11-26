using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTree.DAL.Repository
{
    public class TreeNodeRepository : BaseRepository<tbl_TreeNode>
    {
        public TreeNodeRepository() : base() { }

        public TreeNodeRepository(FolderTreeEntities context) : base(context) { }

        public override int Create(tbl_TreeNode entity)
        {
            dbContext.tbl_TreeNode.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        public override bool CreateRange(List<tbl_TreeNode> listEntities)
        {
            try
            {
                dbContext.tbl_TreeNode.AddRange(listEntities);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Delete(int id)
        {
            try
            {
                var entityToRemove = dbContext.tbl_TreeNode.Find(id);
                dbContext.tbl_TreeNode.Remove(entityToRemove);

                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool DeleteRange(List<tbl_TreeNode> listEntities)
        {
            try
            {
                dbContext.tbl_TreeNode.RemoveRange(listEntities);

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override DbSet<tbl_TreeNode> GetEntities()
        {
            return dbContext.tbl_TreeNode;
        }

        public override tbl_TreeNode GetEntity(int id)
        {
            return dbContext.tbl_TreeNode.Find(id);
        }

        public override bool Update(tbl_TreeNode entity)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool UpdateRange(List<tbl_TreeNode> listEntities)
        {
            try
            {
                listEntities.ForEach(delegate (tbl_TreeNode updateObj)
                {
                    dbContext.Entry(updateObj).State = EntityState.Modified;
                });

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
