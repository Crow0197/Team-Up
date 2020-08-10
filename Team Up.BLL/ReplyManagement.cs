using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.DAL;
using Team_Up.DAL.EF;
using Team_Up.Entities;
using Team_Up.Models;

namespace Team_Up.BLL
{
    public class ReplyManagement
    {

        IRepositoryReply replyRepository = new RepositoryReply();
        AccountManagement am = new AccountManagement();

        public bool Create(ReplyModel reply)
        {
            Reply entity = new Reply();

            Mapping mapping = new Mapping();
            
            mapping.MapObjects(reply, entity);

            entity.UserName = reply.UserName;

            return replyRepository.Create(entity);

        }



        public List<ReplyModel> GetReplyForTask(int id)
        {
            List<ReplyModel> replyModels = new List<ReplyModel>();


            Mapping mapping = new Mapping();

            List<Reply> dbEntity = replyRepository.GetAllForTask(id); ;


            if (dbEntity != null)
            {
                foreach (var item in dbEntity)
                {
                    ReplyModel newItem = new ReplyModel();
                    mapping.MapObjects(item, newItem);

                    AccountModel newAccount = new AccountModel();
                    mapping.MapObjects(am.GetAccountForUsername(newItem.UserName), newAccount);
                    newItem.AccountDetails = newAccount;
                    replyModels.Add(newItem);


                }

                
            }



            

            return replyModels;

        }


    }
}
