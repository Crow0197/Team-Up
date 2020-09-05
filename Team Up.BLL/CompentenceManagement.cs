using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team_Up.BLL;
using Team_Up.DAL;
using Team_Up.DAL.EF;
using Team_Up.Entities;
using Team_Up.Models;

namespace Team_Up
{
    public class CompentenceManagement
    {
        IRepositoryCompentence compenteRepository = new RepositoryCompentence();


        public List<CompetenceModel> getAll()
        {

            Mapping mapping = new Mapping();
            List<CompetenceModel> competenceModels = new List<CompetenceModel>();

            var compenteDB = compenteRepository.GetAll();



            if (compenteDB.Count != 0)
            {
                foreach (var item in compenteDB)
                {
                    CompetenceModel competence = new CompetenceModel();
                    mapping.MapObjects(item, competence);
                    competenceModels.Add(competence);
                }




            }



            return competenceModels;
        }


        public List<CompetenceModel> getAllForAccount(string account)
        {

            Mapping mapping = new Mapping();
            List<CompetenceModel> competenceModels = new List<CompetenceModel>();
            var compenteDB = compenteRepository.getAllForAccount(account);

            if (compenteDB.Count != 0)
            {
                foreach (var item in compenteDB)
                {
                    CompetenceModel competence = new CompetenceModel();
                    mapping.MapObjects(item, competence);
                    competenceModels.Add(competence);
                }


            }



            return competenceModels;
        }



        public List<CompetenceModel> getAllForProject(int id)
        {

            Mapping mapping = new Mapping();
            List<CompetenceModel> competenceModels = new List<CompetenceModel>();
            var compenteDB = compenteRepository.getAllForProject(id);

            if (compenteDB.Count != 0)
            {
                foreach (var item in compenteDB)
                {
                    CompetenceModel competence = new CompetenceModel();
                    mapping.MapObjects(item, competence);
                    competenceModels.Add(competence);
                }


            }



            return competenceModels;
        }


        public Competence getOneEntity(int id)
        {
            return compenteRepository.GetOne(id);
        }

        public CompetenceModel getOne(int id)
        {
            Mapping mapping = new Mapping();
            CompetenceModel newCompetenceModel = new CompetenceModel();
            var cm = compenteRepository.GetOne(id);
            if (cm != null)
                mapping.MapObjects(cm, newCompetenceModel);
            return newCompetenceModel;
        }


        public CompetenceModel getOne(string name)
        {
            Mapping mapping = new Mapping();
            CompetenceModel newCompetenceModel = new CompetenceModel();
            var cm = compenteRepository.GetOne(name);
            if (cm != null)
                mapping.MapObjects(cm, newCompetenceModel);
            return newCompetenceModel;
        }

       
        public void Delete(int id)
        {
            compenteRepository.Delete(compenteRepository.GetOne(id));
        }



        public void Create(CompetenceModel cm)
        {

            Mapping mapping = new Mapping();
            Competence competence = new Competence();
            mapping.MapObjects(cm, competence);
            compenteRepository.Create(competence);


        }

    }
}