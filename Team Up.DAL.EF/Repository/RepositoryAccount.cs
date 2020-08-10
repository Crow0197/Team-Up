using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF.Repository
{
    public class RepositoryAccount : IRepositoryAccount
    {
              



        public bool Create(Account account, int[] competencey)
        {
            TeamUpContext db = new TeamUpContext();


            List<Competence> listCompetences = new List<Competence>();

            if (competencey != null)
                foreach (var item in competencey)
                {
                    listCompetences.Add(db.Competences.FirstOrDefault(c => c.CompetenceID == item));
                }

            account.Competences = listCompetences;
                       


            if (GetOne(account.UserName) == null)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                
                return true;
            }
            else
            {
                return false;
            }

        }

        public Account GetOne(int id)
        {
            TeamUpContext db = new TeamUpContext();
            Account account = new Account();
            account = db.Accounts.FirstOrDefault(a => a.AccountID == id);
            return account;
        }

        public Account GetOne(string username)
        {
            TeamUpContext db = new TeamUpContext();
            Account account = new Account();
            account = db.Accounts.FirstOrDefault(a => a.UserName == username);
            return account;
        }


        public Account GetOneEmail(string email)
        {
            TeamUpContext db = new TeamUpContext();
            Account account = new Account();
            account = db.Accounts.FirstOrDefault(a => a.Email == email);
            return account;
        }



        public bool Delete(Account account)
        {
            TeamUpContext db = new TeamUpContext();
            db.Accounts.Remove(account);
            return true;
        }
        public List<Account> GetAll()
        {
            TeamUpContext db = new TeamUpContext();
            return db.Accounts.ToList();
        }

        public void Save()
        {
            TeamUpContext db = new TeamUpContext();
            Account account = new Account();
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public bool Update(Account account)
        {
            try
            {
                TeamUpContext db = new TeamUpContext();
                var dbAccount = db.Accounts.First(a => a.UserName == account.UserName);
                dbAccount.Avatar = account.Avatar;
               



                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

            

        }

    }

}
