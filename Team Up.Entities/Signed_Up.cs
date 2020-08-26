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
        public int Id { get; set; }
        public virtual string Account { get; set; }
        public virtual int Project { get; set; }
        public bool IsRegistered { get; set; }
        public bool RequestConfirmed { get; set; }

        //public virtual ICollection<RoleOnTheProject> SignedUp { get; set; }


    }
}
