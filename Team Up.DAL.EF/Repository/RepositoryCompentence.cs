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

        public Competence GetOne(int idSearch)
        {
            throw new NotImplementedException();
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
