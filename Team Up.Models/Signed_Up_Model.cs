using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Models
{
    public class Signed_Up_Model
    {
        public int Id { get; set; }
        public virtual string Account { get; set; }
        public virtual int Project { get; set; }
        public bool IsRegistered { get; set; }
        public bool RequestConfirmed { get; set; }
    }
}
