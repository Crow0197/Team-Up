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



            if (GetOne(account.UserName) == null && GetOneEmail(account.Email) == null)
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
            account = db.Accounts.FirstOrDefault(a => a.AccountID == id && a.isClose != true);
            return account;
        }

        public Account GetOne(string username)
        {
            TeamUpContext db = new TeamUpContext();
            Account account = new Account();
            account = db.Accounts.FirstOrDefault(a => a.UserName == username && a.isClose != true);
            return account;
        }


        public Account GetOneEmail(string email)
        {
            TeamUpContext db = new TeamUpContext();
            Account account = new Account();
            account = db.Accounts.FirstOrDefault(a => a.Email == email);
            return account;
        }



        public bool Delete(int id)
        {

            try
            {
                TeamUpContext db = new TeamUpContext();
                var accountDelete = db.Accounts.First(x => x.AccountID == id);
                // db.Accounts.Remove(accountDelete);
                // db.Database.ExecuteSqlCommand("Delete from [CompetenceAccounts] where [UserName] = '" + accountDelete.UserName + "'");
                accountDelete.isClose = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<Account> GetAll()
        {
            TeamUpContext db = new TeamUpContext();
            return db.Accounts.Where(x => x.isClose != true).ToList();
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


                if (account.Avatar != null)
                    dbAccount.Avatar = account.Avatar;

                if (account.DateOfBirth > new DateTime(1900, 01, 01))
                    dbAccount.DateOfBirth = account.DateOfBirth;

                if (account.UserName != null)
                    dbAccount.UserName = account.UserName;

                if (account.Name != null)
                    dbAccount.Name = account.Name;

                if (account.Surname != null)
                    dbAccount.Surname = account.Surname;

                if (account.Email != null)
                    dbAccount.Email = account.Email;

                if (account.Password != null)
                    dbAccount.Password = account.Password;

                if (account.Competences != null)
                {
                    db.Database.ExecuteSqlCommand("Delete from [CompetenceAccounts] where [UserName] = '" + account.UserName + "'");


                    List<Competence> listCompetences = new List<Competence>();

                    foreach (var item in account.Competences)
                    {
                        listCompetences.Add(db.Competences.FirstOrDefault(c => c.CompetenceID == item.CompetenceID));
                    }

                    dbAccount.Competences = listCompetences;

                }


                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }

    }

}
