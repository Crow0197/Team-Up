using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
    public interface IRepositoryAccount
    {
        Account GetOne(int idSearch);

        Account GetOne(string Username);

        Account GetOneEmail(string email);
        
        bool Update(Account account);

        Boolean Delete(Account account);
        List<Account> GetAll();
        bool Create(Account account, int[] competence);
        void Save();

    }


}
