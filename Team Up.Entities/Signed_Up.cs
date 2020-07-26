using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Entities
{
    public class Signed_Up
    {

        [Key, Column(Order = 0)]
        public int AccountID { get; set; }
        [Key, Column(Order = 1)]
        public int ProjectID { get; set; }
            
           

        public virtual Account Account { get; set; }
        public virtual Project Project { get; set; }

        //public virtual ICollection<RoleOnTheProject> SignedUp { get; set; }


    }
}
