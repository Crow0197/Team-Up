using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF.Repository
{
    public class RepositoryProject : IRepositoryProject
    {
        TeamUpContext db1 = new TeamUpContext();


        public bool Create(Project project, string account, int[] idCompentece, int[] idCategory)
        {

            project.AccountID = db1.Accounts.FirstOrDefault(c => c.UserName == account);

            List<Competence> listCompetences = new List<Competence>();

            if (idCompentece != null)
                foreach (var item in idCompentece)
                {
                    listCompetences.Add(db1.Competences.FirstOrDefault(c => c.CompetenceID == item));
                }

            project.Competences = listCompetences;



            List<Category> listCategory = new List<Category>();

            if (idCategory != null)
                foreach (var item in idCategory)
                {
                    listCategory.Add(db1.Categories.FirstOrDefault(c => c.CategoryID == item));
                }

            project.Categories = listCategory;



            db1.Projects.Add(project);
            db1.SaveChanges();

            return true;
        }

        public bool Delete(Project project)
        {

            var projectDelete = db1.Projects.First(x => x.ProjectID == project.ProjectID);
            db1.Database.ExecuteSqlCommand("Delete from [CategoryProjects] where [Project_ProjectID] = '" + projectDelete.ProjectID + "'");
            db1.Database.ExecuteSqlCommand("Delete from [CompetenceProjects] where [ProjectID] = '" + projectDelete.ProjectID + "'");
            db1.Database.ExecuteSqlCommand("Delete from[Projects] where [ProjectID] = '" + projectDelete.ProjectID + "'");
            db1.SaveChanges();
            return true;
        }

        public List<Project> GetAll()
        {
            var listProject = db1.Projects.ToList();


            foreach (var item in listProject)
            {
                var getAccount = GetAccount(item.ProjectID);

                if (getAccount != null)
                {
                    item.AccountID = getAccount;
                }


                var getCompetence = GetCompetence(item.ProjectID);


                if (getCompetence != null && getCompetence.CompetenceID != 0)
                {
                    item.Competences.Add(getCompetence);
                }
            }
            return db1.Projects.ToList();
        }

        public Account GetAccount(int id)
        {



            var account = db1.Accounts.SqlQuery("SELECT DISTINCT   account.* FROM  [Projects] [Projects]  inner join [Accounts] account  on account.UserName = [Projects].AccountID_UserName where  [ProjectID] =  " + id).ToList();

            Account getAccount = new Account();

            if (account.Count > 0)
            {
                getAccount = account.First();
            }

            return getAccount;
        }


        public Competence GetCompetence(int id)
        {
            var competence = db1.Competences.SqlQuery("SELECT DISTINCT cm.*  FROM [CompetenceProjects] pc INNER JOIN [Competences]  cm  on pc.[CompetenceID] = cm.CompetenceID   where pc.[ProjectID] =" + id).ToList();
            Competence getCompetence = new Competence();
            if (competence.Count > 0)
            {
                getCompetence = competence.First();
            }

            return getCompetence;
        }


        public Category GetCategorys(int id)
        {
            var category = db1.Categories.SqlQuery("SELECT DISTINCT ca.*  FROM CategoryProjects pc  INNER JOIN Categories  ca on pc.Project_ProjectID = ca.CategoryID where pc.Project_ProjectID = " + id).ToList();
            Category getCategory = new Category();
            if (category.Count > 0)
            {
                getCategory = category.First();
            }

            return getCategory;
        }



        public Project GetOne(int idSearch)
        {
            Project project = new Project();

            project = db1.Projects.FirstOrDefault(x => x.ProjectID == idSearch);

            var getAccount = GetAccount(project.ProjectID);
            if (getAccount != null)
            {
                project.AccountID = getAccount;
            }

            var getCompetence = GetCompetence(project.ProjectID);

            if (getCompetence != null && getCompetence.CompetenceID != 0)
            {
                project.Competences.Add(getCompetence);
            }


            var getCategories = GetCategorys(project.ProjectID);

            if (getCategories != null && getCategories.CategoryID != 0)
            {
                project.Categories.Add(getCategories);
            }




            return project;

        }

        public Project GetOne(string Username)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Project project, string account, int[] idCompentece, int[] idCategory)
        {

            var projectOld = GetOne(project.ProjectID);


            if (project.Date != null)
                projectOld.Date = project.Date;
            if (project.Description != null)
                projectOld.Description = project.Description;
            if (project.Title != null)
                projectOld.Title = project.Title;


            projectOld.Competences.Clear();
            projectOld.Categories.Clear();

            List<Competence> listCompetences = new List<Competence>();

            if (idCompentece != null)
                foreach (var item in idCompentece)
                {
                    listCompetences.Add(db1.Competences.FirstOrDefault(c => c.CompetenceID == item));
                }

            projectOld.Competences = listCompetences;


            List<Category> listCategory = new List<Category>();

            if (idCategory != null)
                foreach (var item in idCategory)
                {
                    listCategory.Add(db1.Categories.FirstOrDefault(c => c.CategoryID == item));
                }

            projectOld.Categories = listCategory;


            db1.SaveChanges();

            return true;
        }
    }

}
