using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL.EF
{
    public class TeamUpContext : DbContext
    {
               
        public TeamUpContext() : base("TeamUpContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TeamUpContext>());
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Signed_Up> Inscriptions { get; set; }
        public DbSet<TaskP> Tasks { get; set; }
        public DbSet<Reply> Replies { get; set; }

        // public DbSet<RoleOnTheProject> RolesOnTheProjects { get; set; }

        



    }
}
