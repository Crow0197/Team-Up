using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.DAL;
using Team_Up.DAL.EF.Repository;
using Team_Up.Entities;
using Team_Up.Models;

namespace Team_Up.BLL
{
    public class AccountManagement
    {
        IRepositoryAccount accountRepository;

        

        public AccountManagement()
        {

            accountRepository = new RepositoryAccount();
        }

        public bool Registration(AccountModel newAccont)
        {
            Account entityAccounts = new Account();
            Mapping mapping = new Mapping();
            Encryption encryption = new Encryption();
            //var provaps = encryption.base64Encode("ciao");
            //provaps = encryption.base64Decode2(provaps);
            mapping.MapObjects(newAccont,entityAccounts);
            entityAccounts.Password = encryption.base64Encode(entityAccounts.Password); 
           return  accountRepository.Create(entityAccounts);
        }


        public AccountModel GetAccountForId(int id)
        {
            AccountModel account = new AccountModel();
            Mapping mapping = new Mapping();

            Account accountDB = accountRepository.GetOne(id);

            if (accountDB != null) {
                mapping.MapObjects(accountDB, account);
            }
          
            return account;
        }


        public bool LoginCertification(string userName,string password)
        {

            bool success = false;

            AccountModel account = new AccountModel();
            Mapping mapping = new Mapping();


            Account accountDB = accountRepository.GetOne(userName);

            if (accountDB != null)
            {

                mapping.MapObjects(accountDB, account);

                Encryption encryption = new Encryption();
                string encryptedPassword = encryption.base64Encode(password);

                if (account.Password == encryptedPassword && account.UserName == userName)
                {
                    success = true;
                }
            }

            else {
                success = false;
            }

            
            return success;
        }





        public void ChangeAvatar(string username, string fileName)       
        {
            Account account = new Account();

            account = accountRepository.GetOne(username);        
            account.Avatar = fileName;
            accountRepository.Update(account);
        }


        public AccountModel GetAccountForUsername(string username) {
           
            AccountModel account = new AccountModel();
            Mapping mapping = new Mapping();
            Account accountDB = accountRepository.GetOne(username);
            if (accountDB != null)
            {
                mapping.MapObjects(accountDB, account);
            }
            return account;
        }


    }
}
