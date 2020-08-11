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
            throw new NotImplementedException();
        }

        public bool Delete(Competence competence)
        {
            throw new NotImplementedException();
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


        public Competence GetOne(int idSearch)
        {
            return dbCompentence.Competences.FirstOrDefault(x=> x.CompetenceID == idSearch);
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
