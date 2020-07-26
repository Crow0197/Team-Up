using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Team_Up.Entities
{
   public class Reply
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplyID { get; set; }

        public Topic TopicID { get; set; }

        public Account AccountCreator { get; set; }


    }
}
