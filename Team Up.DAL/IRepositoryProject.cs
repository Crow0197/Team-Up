using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
    public interface IRepositoryProject
    {
        Project GetOne(int idSearch);

        Project GetOne(string Username);
        bool Update(Project project, string account, int[] idCompentece, int[] idCategory);
        Boolean Delete(Project project);
        List<Project> GetAll();
        bool Create(Project project, string account, int[] competence, int[] category);
        int SignedUp(Project project, Account account);

        Signed_Up AcceptRegistration(int id, bool reply);

        bool isRegistered(int idP, string  User);
        bool isRequest(int idP, string  User);
        
        void Save();

        bool CloseAndOpen(int idP, bool CloseOpen);
        IList<Signed_Up> registeredUsers(int idP);

        IList<Project> getSignedUpProject(string user);
    }


}
