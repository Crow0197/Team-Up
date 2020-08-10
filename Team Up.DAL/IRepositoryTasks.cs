using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
    public interface IRepositoryTasks
    {

        TaskP GetOne(int idSearch);
        void Update(TaskP task);
        Boolean Delete(TaskP task);

        List<TaskP> GetAll();

        List<TaskP> GetAllFromProject(int projectID);

        bool Create(TaskP task);
        void Save();
    }
}
