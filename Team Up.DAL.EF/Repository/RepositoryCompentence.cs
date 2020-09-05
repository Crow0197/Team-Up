using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF
{
    public class RepositoryCompentence : IRepositoryCompentence
    {

        TeamUpContext dbCompentence = new TeamUpContext();

        public bool Create(Competence competence)
        {

            try
            {
                dbCompentence.Competences.Add(competence);
                dbCompentence.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool Delete(Competence competence)
        {
            dbCompentence.Competences.Remove(competence);
            dbCompentence.SaveChanges();
            return true;
        }

        public List<Competence> GetAll()
        {
           
            return dbCompentence.Competences.ToList();
            
        }
        

        public List<Competence> getAllForAccount(string username)
        {
            var competence = dbCompentence.Competences.SqlQuery("  SELECT DISTINCT cm.*  FROM [CompetenceAccounts] ac  INNER JOIN[Competences] cm on ac.[CompetenceID] = cm.CompetenceID  where ac.[UserName] = '" + username + "'").ToList();
             return competence;

        }

        public List<Competence> getAllForProject(int id)
        {
            var competence = dbCompentence.Competences.SqlQuery("SELECT cm.* FROM [CompetenceProjects] pc INNER JOIN[Competences] cm on pc.[CompetenceID] = cm.CompetenceID    where [ProjectID] =" + id).ToList();
            return competence;
        }

        public Competence GetOne(int idSearch)
        {
            return dbCompentence.Competences.FirstOrDefault(x=> x.CompetenceID == idSearch);
        }

        public Competence GetOne(string Search)
        {
            return dbCompentence.Competences.FirstOrDefault(x => x.typology.ToUpper() == Search);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Competence competence)
        {
            throw new NotImplementedException();
        }
    }
}
