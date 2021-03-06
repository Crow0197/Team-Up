﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.DAL;
using Team_Up.DAL.EF.Repository;
using Team_Up.Entities;
using Team_Up.Models;
using System.Net.Mail;
using System.Net;
using Team_Up.DAL.EF;

namespace Team_Up.BLL
{
    public class ProjectManagement
    {
        IRepositoryProject projectRepository;
        IRepositoryAccount accoutM;
        IRepositoryConfig configSystenm;
        TaskManagement taskManagement;


        public ProjectManagement()
        {

            projectRepository = new RepositoryProject();
            accoutM = new RepositoryAccount();
            taskManagement = new TaskManagement();
            configSystenm = new RepositoryConfig();
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


        public List<ProjectModel> getAll()
        {


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



        public bool Delete(int id)
        {

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


        public bool SignedUp(int id, AccountModel creator, AccountModel user)
        {

            Project project = new Project();
            Mapping mapping = new Mapping();

            project = projectRepository.GetOne(id);


            Account userDb = new Account();
            mapping.MapObjects(user, userDb);
            var idSigneUp = projectRepository.SignedUp(project, userDb);


            var systemEmail = configSystenm.GetOne("EmailSystem");
            var systemEmailPass = configSystenm.GetOne("PassEmail");



            string url = "http://www.cross-team.it/Project/AcceptRegistration/?idSignedUp=" + idSigneUp + "&accepted=";
            MailMessage message = new MailMessage();
            message.To.Add(creator.Email);
            message.Subject = "Iscrizione Progetto " + project.Title;
            message.IsBodyHtml = true;

            message.Body = "L'utente " + user.UserName + " Vuole iscriversi al tuo progetto... OK ?<br> <a href=\"" + url + "true" + "\">Si</a> ! <a href=\"" + url + "false" + "\">No</a>";
            message.From = new MailAddress(systemEmail, "Iscrizione" + project.Title.ToUpper());
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(systemEmail, systemEmailPass);
            smtp.Send(message);





            return true;

        }

        public int AcceptRegistration(int id, bool reply)
        {

            var signer= projectRepository.AcceptRegistration(id, reply);
            var account =accoutM.GetOne(signer.Account);

            var title = projectRepository.GetOne(signer.Project).Title;

            MailMessage message = new MailMessage();
            message.To.Add(account.Email);
            message.Subject = "Iscrizione Progetto " + title;
            message.IsBodyHtml = true;

            message.Body = "La tua richiesta di iscrizione al progetto " + title + " è stata: ";

            if (reply) { message.Body += "Confermata"; }
            else message.Body += "Rifiutata";

            var systemEmail = configSystenm.GetOne("EmailSystem");
            var systemEmailPass = configSystenm.GetOne("PassEmail");

            message.From = new MailAddress("nonreplaycrossteam@gmail.com", "Iscrizione: " + title);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(systemEmail, systemEmailPass);
            smtp.Send(message);


            return signer.Project;


        }


        public bool isRegistered(int idP, string User)
        {

            return projectRepository.isRegistered(idP, User);



        }


        public bool isRequest(int idP, string User)
        {
            return projectRepository.isRequest(idP, User);
        }

        public IList<Signed_Up_Model> registeredUsers(int idP)
        {
            Mapping mapping = new Mapping();
            IList<Signed_Up_Model> signed_Up_Models = new List<Signed_Up_Model>();

            foreach (var item in projectRepository.registeredUsers(idP))
            {
                Signed_Up_Model itemAdd = new Signed_Up_Model();

                mapping.MapObjects(item, itemAdd);
                signed_Up_Models.Add(itemAdd);

            }
           
            return signed_Up_Models;
        }


        public bool CloseAndOpen(int idP, bool CloseOpen) {

            projectRepository.CloseAndOpen(idP,CloseOpen);

            var taskList = taskManagement.GetFromProject(idP);

            foreach (var item in taskList)
            {
                taskManagement.CloseOrOpen(item.TaskID, CloseOpen);
            }

            return true;
        
        }


        public IList<ProjectModel> getSignedUpProject(string user)
        {
            Mapping mapping = new Mapping();
            IList<ProjectModel> projects = new List<ProjectModel>();

            foreach (var item in projectRepository.getSignedUpProject(user))
            {
                ProjectModel itemAdd = new ProjectModel();

                mapping.MapObjects(item, itemAdd);
                projects.Add(itemAdd);

            }

            return projects;
        }




    }
}
