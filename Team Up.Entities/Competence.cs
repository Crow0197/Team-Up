using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Entities
{
    public class Competence
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetenceID { get; set; }

        public string typology { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public Competence()
        {
            this.Accounts = new HashSet<Account>();
        }


    }
}
