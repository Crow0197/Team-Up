﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Entities
{
    public class Project
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        public string Title { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [Column("CreatorAccount")]
        public Account CreatorAccount { get; set; }

        public virtual ICollection<Signed_Up> SignedUp { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

    }
}