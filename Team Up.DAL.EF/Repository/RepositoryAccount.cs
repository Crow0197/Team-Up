﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF.Repository
{
    public class RepositoryAccount : IRepositoryAccount
    {

        TeamUpContext db = new TeamUpContext();



        public bool Create(Account account)
        {
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
            Account account = new Account();
            account = db.Accounts.SingleOrDefault(a => a.AccountID == id);
            return account;
        }

        public Account GetOne(string username)
        {
            Account account = new Account();
            account = db.Accounts.SingleOrDefault(a => a.UserName == username);
            return account;
        }

        public bool Delete(Account account)
        {
            db.Accounts.Remove(account);
            return true;
        }
        public List<Account> GetAll()
        {
            return db.Accounts.ToList();
        }

        public void Save()
        {
            Account account = new Account();
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public void Update(Account account)
        {
            var dbAccount = db.Accounts.First(a => a.UserName == account.UserName);
            Type sourcetype = account.GetType();
            Type destinationtype = dbAccount.GetType();
            var sourceProperties = sourcetype.GetProperties();
            var destionationProperties = destinationtype.GetProperties();
            var commonproperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };
            foreach (var match in commonproperties)
            {
                match.dp.SetValue(dbAccount, match.sp.GetValue(account, null), null);
            }

            db.SaveChanges();

        }

    }

}
