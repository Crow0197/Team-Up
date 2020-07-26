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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TeamUpContext>());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Competence> Competences { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectRole> ProjectRoles { get; set; }


        public DbSet<Signed_Up> Inscriptions { get; set; }

       // public DbSet<RoleOnTheProject> RolesOnTheProjects { get; set; }

        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                        .HasMany<Competence>(s => s.Competences)
                        .WithMany(c => c.Accounts)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("CompetenceID");
                            cs.MapRightKey("UserName");
                            cs.ToTable("Select_Competence");
                        });



            //modelBuilder.Entity<Account>()
            //            .HasMany<Project>(s => s.RegisteredProjects)
            //            .WithMany(c => c.SignedUp)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("ProjectID");
            //                cs.MapRightKey("AccountID");
            //                cs.ToTable("Signed_Up");
            //            });


        }




    }
}
