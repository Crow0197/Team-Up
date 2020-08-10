using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.DAL;
using Team_Up.DAL.EF.Repository;
using Team_Up.Entities;
using Team_Up.Models;

namespace Team_Up.BLL
{
    public class TaskManagement
    {
        IRepositoryTasks taskRepository;

        public TaskManagement()
        {
            taskRepository = new RepositoryTasks();
        }


        public bool Create(TaskModel taskM) {

            TaskP entity = new TaskP();

            Mapping mapping = new Mapping();
            Account createAccount = new Account();
            Project orginProject = new Project();
          

            mapping.MapObjects(taskM, entity);

            entity.ProjectID = taskM.Project;
            entity.UserName = taskM.AccountCreator;

            return taskRepository.Create(entity);


       
        }


        public List<TaskModel> GetAll()
        {
            List<TaskModel> taskM = new List<TaskModel>();
            Mapping mapping = new Mapping();

            List<TaskP> taskDb = taskRepository.GetAll();

            if (taskDb != null)
            {
                mapping.MapObjects(taskDb, taskM);
            }

            return taskM;
        }


        public TaskModel GetOne(int id)
        {
            TaskModel taskM = new TaskModel();
            Mapping mapping = new Mapping();

            TaskP taskDb = taskRepository.GetOne(id);

            if (taskDb != null)
            {
                mapping.MapObjects(taskDb, taskM);
            }

            taskM.AccountCreator = taskDb.UserName;
            taskM.Project = taskDb.ProjectID;

            return taskM;
        }




        public List<TaskModel> GetFromProject(int id)
        {
            List<TaskModel> taskList = new List<TaskModel>();
            Mapping mapping = new Mapping();

            List<TaskP> taskDb = taskRepository.GetAllFromProject(id);

            if (taskDb != null)
            {
                foreach (var item in taskDb)
                {
                    TaskModel itemTask = new TaskModel();                    
                    mapping.MapObjects(item, itemTask);
                    taskList.Add(itemTask);

                }
                
            }

            return taskList;
        }




    }
}
