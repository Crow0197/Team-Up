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
    public class ProjectManagement
    {
        IRepositoryProject projectRepository;      
       


        public ProjectManagement()
        {

            projectRepository = new RepositoryProject();
        }


        public bool Create(ProjectModel newProject, int[] idCompentece, int[] idCategory)
        {
            Mapping mapping = new Mapping();
            Project newProjectEntity = new Project();
            mapping.MapObjects(newProject, newProjectEntity);
            List<Competence> competences = new List<Competence>();
            newProjectEntity.Date = newProject.Date;
            return projectRepository.Create(newProjectEntity, newProject.CreatorAccount, idCompentece, idCategory);
        }



        public bool Update(ProjectModel newProject, int[] idCompentece, int[] idCategory)
        {
            Mapping mapping = new Mapping();
            Project newProjectEntity = new Project();
            mapping.MapObjects(newProject, newProjectEntity);   
            return projectRepository.Update(newProjectEntity, newProject.CreatorAccount, idCompentece, idCategory);
        }


        public List<ProjectModel> getAll() {


            Mapping mapping = new Mapping();
            List<ProjectModel> projectModels = new List<ProjectModel>();
            var dbGet = projectRepository.GetAll();

            if (dbGet.Count != 0)
            {
                foreach (var item in dbGet)
                {
                    ProjectModel addItem = new ProjectModel();
                    mapping.MapObjects(item, addItem);
                    addItem.CreatorAccount = item.AccountID.UserName;

                    List<CompetenceModel> competenceModelsAdd = new List<CompetenceModel>();

                    foreach (var item2 in item.Competences)
                    {
                        var competencesAdd = new CompetenceModel();
                        mapping.MapObjects(item2, competencesAdd);
                        competenceModelsAdd.Add(competencesAdd);
                    }
                    addItem.Competences = competenceModelsAdd;


                    List<CategoryModel> categoryModelsAdd = new List<CategoryModel>();

                    foreach (var item2 in item.Categories)
                    {
                        var categoryAdd = new CategoryModel();
                        mapping.MapObjects(item2, categoryAdd);
                        categoryModelsAdd.Add(categoryAdd);
                    }
                    addItem.Categories = categoryModelsAdd;




                    projectModels.Add(addItem);

                }

           }


            return projectModels;
           
        }



        public bool Delete(int id) {

            projectRepository.Delete(projectRepository.GetOne(id));
            return true;
        }



        public ProjectModel getOne(int id = 1)
        {
            Mapping mapping = new Mapping();
            ProjectModel getProjectModel = new ProjectModel();
            var dbGet = projectRepository.GetOne(id);
            mapping.MapObjects(dbGet, getProjectModel);

            getProjectModel.CreatorAccount = dbGet.AccountID.UserName;

            List<CompetenceModel> competenceModelsAdd = new List<CompetenceModel>();

            foreach (var item2 in dbGet.Competences)
            {
                var competencesAdd = new CompetenceModel();
                mapping.MapObjects(item2, competencesAdd);
                competenceModelsAdd.Add(competencesAdd);
            }
            getProjectModel.Competences = competenceModelsAdd;


            List<CategoryModel> categoryModelsAdd = new List<CategoryModel>();

            foreach (var item2 in dbGet.Categories)
            {
                var categoryAdd = new CategoryModel();
                mapping.MapObjects(item2, categoryAdd);
                categoryModelsAdd.Add(categoryAdd);
            }
            getProjectModel.Categories = categoryModelsAdd;
            return getProjectModel;
        }



    }
}
