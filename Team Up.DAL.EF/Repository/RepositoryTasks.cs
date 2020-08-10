using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF.Repository
{
    public class RepositoryTasks : IRepositoryTasks
    {
        public bool Create(TaskP task)
        {
            TeamUpContext dbTask = new TeamUpContext();
            dbTask.Tasks.Add(task);
            dbTask.SaveChanges();
            return true;
        }

        public bool Delete(TaskP task)
        {
            throw new NotImplementedException();
        }

        public List<TaskP> GetAll()
        {
            TeamUpContext dbTask = new TeamUpContext();            
            return dbTask.Tasks.ToList();
        }

        public List<TaskP> GetAllFromProject(int projectID)
        {
            TeamUpContext dbTask = new TeamUpContext();
            return dbTask.Tasks.Where(x => x.ProjectID == projectID).ToList();
        }

        public TaskP GetOne(int idSearch)
        {
            TeamUpContext dbTask = new TeamUpContext();
            return dbTask.Tasks.First(x => x.TaskID == idSearch);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TaskP task)
        {
            throw new NotImplementedException();
        }
    }
}
