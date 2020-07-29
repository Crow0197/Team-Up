using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
      public interface IRepositoryCompentence
    {
        Competence GetOne(int idSearch);        
        void Update(Competence competence);
        Boolean Delete(Competence competence);
        List<Competence> GetAll();

        bool Create(Competence competence);
        void Save();

    }
}
