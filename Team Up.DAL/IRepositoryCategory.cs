using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
    public interface IRepositoryCategory
    {

        Category GetOne(int idSearch);
        void Update(Category category);
        Boolean Delete(Category compecategorytence);
        List<Category> GetAll();
        List<Category> getAllForProject(int id);
        bool Create(Category category);
        void Save();



    }
}
