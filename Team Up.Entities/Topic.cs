using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Entities
{
    public class Topic
    {

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Account CreatoAccount { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }


    }
}
