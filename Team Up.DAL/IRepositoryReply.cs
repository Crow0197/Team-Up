using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
    public interface IRepositoryReply
    {
        Reply GetOne(int idSearch);
        void Update(Reply reply);
        Boolean Delete(Reply reply);
        List<Reply> GetAll();
        List<Reply> GetAllForTask(int i);
        List<Reply> GetAllFromProject(int projectID);
        bool Create(Reply reply);
        void Save();
    }
}
