using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF
{
    public class RepositoryCategory : IRepositoryCategory
    {
        public bool Create(Category category)
        {
            TeamUpContext dbCategory = new TeamUpContext();
            try
            {
                dbCategory.Categories.Add(category);
                dbCategory.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int category)
        {
            TeamUpContext dbCategory = new TeamUpContext();
            dbCategory.Database.ExecuteSqlCommand("delete from [Categories] where [CategoryID] =" + category);
            dbCategory.Database.ExecuteSqlCommand("Delete from [CategoryProjects] where [Category_CategoryID] = " + category);
            dbCategory.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            TeamUpContext dbCategory = new TeamUpContext();
            return dbCategory.Categories.ToList();
        }

        public List<Category> getAllForProject(int id)
        {
            TeamUpContext dbCategory = new TeamUpContext();
            var competence = dbCategory.Categories.SqlQuery("SELECT cm.* FROM [CategoryProjects] pc INNER JOIN [Categories] cm on pc.[Category_CategoryID] = cm.[CategoryID]  where  [Project_ProjectID]= " + id).ToList();
            return competence;
        }

        public Category GetOne(int idSearch)
        {
            TeamUpContext dbCategory = new TeamUpContext();
            return dbCategory.Categories.FirstOrDefault(x=> x.CategoryID == idSearch) ;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
