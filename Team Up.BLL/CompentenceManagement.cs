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

            

            if (compenteDB.Count != 0) {
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


        public Competence getOne(int id) {       
            return compenteRepository.GetOne(id);
        }


    }
}