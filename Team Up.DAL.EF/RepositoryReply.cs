using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF
{
    public class RepositoryReply : IRepositoryReply
    {
        public bool Create(Reply reply)
        {
            TeamUpContext dbReply = new TeamUpContext();

          
                dbReply.Replies.Add(reply);
                dbReply.SaveChanges();
                return true;
          
           
        }

        public bool Delete(Reply reply)
        {
            throw new NotImplementedException();
        }

        
        public List<Reply> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Reply> GetAllForTask(int i)
        {
            TeamUpContext dbReply = new TeamUpContext();
            return dbReply.Replies.Where(x => x.TaskID == i).ToList();
        }

        public List<Reply> GetAllFromProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public Reply GetOne(int idSearch)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Reply reply)
        {
            throw new NotImplementedException();
        }
    }
}
