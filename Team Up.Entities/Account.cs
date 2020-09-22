using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Team_Up.Entities
{
    public class Account
    {

      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int AccountID { get; set; }
        [Key, Column(Order = 0)]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }      
        public string Email { get; set; }
        public string Password { get; set; }       
        public string TypeAccount { get; set; }
   
        public virtual ICollection<Competence> Competences { get; set; }       
        public virtual ICollection<Signed_Up> SignedUp { get; set; }
        public virtual ICollection<TaskP> Tasks { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public string Avatar { get; set; }
        public bool isClose { get; set; }

    }
}
