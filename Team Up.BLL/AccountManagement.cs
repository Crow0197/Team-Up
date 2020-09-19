using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Team_Up.DAL;
using Team_Up.DAL.EF;
using Team_Up.DAL.EF.Repository;
using Team_Up.Entities;
using Team_Up.Models;

namespace Team_Up.BLL
{
    public class AccountManagement
    {
        IRepositoryAccount accountRepository;
        IRepositoryConfig configSystenm;



        public AccountManagement()
        {

            accountRepository = new RepositoryAccount();
            configSystenm = new RepositoryConfig();
        }

        public bool Registration(AccountModel newAccont, int[] Compentece)
        {
            Account entityAccounts = new Account();
            Mapping mapping = new Mapping();
            Encryption encryption = new Encryption();
            //var provaps = encryption.base64Encode("ciao");
            //provaps = encryption.base64Decode2(provaps);
            mapping.MapObjects(newAccont, entityAccounts);
            entityAccounts.Password = encryption.base64Encode(entityAccounts.Password);



            return accountRepository.Create(entityAccounts, Compentece);
        }


        public AccountModel GetAccountForId(int id)
        {
            AccountModel account = new AccountModel();
            Mapping mapping = new Mapping();

            Account accountDB = accountRepository.GetOne(id);

            if (accountDB != null)
            {
                mapping.MapObjects(accountDB, account);
            }

            return account;
        }


        public bool LoginCertification(string userName, string password)
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

            else
            {
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


        public AccountModel GetAccountForUsername(string username)
        {

            AccountModel account = new AccountModel();
            Mapping mapping = new Mapping();
            Account accountDB = accountRepository.GetOne(username);
            if (accountDB != null)
            {
                mapping.MapObjects(accountDB, account);
            }
            return account;
        }

        public bool PasswordRecovery(string url, string email)
        {

            var systemEmail = configSystenm.GetOne("EmailSystem");
            var systemEmailPass = configSystenm.GetOne("PassEmail");


            var account = accountRepository.GetOneEmail(email);
            if (account != null)
            {
                url = "http://www.cross-team.it/Account/ChangePassword/?user=" + account.UserName;
                MailMessage message = new MailMessage();
                message.To.Add(email);
                message.Subject = "Test Gmail da C#";
                message.IsBodyHtml = true;
                message.Body = "<a href=\"" + url + "\">Link</a>";
                message.From = new MailAddress(systemEmail, "Password Recovery CROSS-TEAM");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(systemEmail, systemEmailPass);
                smtp.Send(message);

                return true;
            }
            return false;
        }


        public bool ChangePassword(string user, string ps)
        {
            var account = accountRepository.GetOne(user);


            if (account != null)
            {
                Encryption encryption = new Encryption();
                account.Password = encryption.base64Encode(ps);
                return accountRepository.Update(account);
            };

            return false;
        }


        public List<AccountModel> getAll()
        {

            List<AccountModel> accountModels = new List<AccountModel>();
            var listDB = accountRepository.GetAll();
            Mapping mapping = new Mapping();



            if (listDB != null)
            {
                foreach (var item in listDB)
                {
                    AccountModel itemE = new AccountModel();
                    mapping.MapObjects(item, itemE);
                    accountModels.Add(itemE);
                }

            }

            return accountModels;



        }

        public bool EditAccount(AccountModel accountM, int[] Compentecey)
        {

            CompentenceManagement cm = new CompentenceManagement();
            Mapping mapping = new Mapping();
            Account accountE = new Account();
            mapping.MapObjects(accountM, accountE);
            IList<Competence> CompetenceyAccount = new List<Competence>();

            if (accountM.Password != null) {
                Encryption encryption = new Encryption();
                accountE.Password = encryption.base64Encode(accountM.Password);
            
            }
           



            foreach (var item in Compentecey)
            {
                var itemC = cm.getOneEntity(item);
                CompetenceyAccount.Add(itemC);
            }

            accountE.Competences = CompetenceyAccount;
            accountRepository.Update(accountE);




            return true;
        }


        public bool Delete(int id)
        {
            accountRepository.Delete(id);
            return true;
        }



    }
}
