using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Entities
{
    public class ProjectRole
    {

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectRoleID { get; set; }
        public string Name { get; set; }

       // public virtual ICollection<RoleOnTheProject> SignedUp { get; set; }


    }


    public class RoleOnTheProject
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleOnTheProjectID { get; set; }
        public virtual ProjectRole ProjectRole { get; set; }
        public virtual Signed_Up Signed_Up { get; set; }



    }


}
