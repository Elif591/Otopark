using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otopark.Models.Model
{
    public partial class User
    {
        public User()
        {
            this.Plates = new HashSet<Plate>();
            this.Capatcies = new HashSet<Capatcy>();
        }

        [Key]
        public int UserId { get; set; }
        public bool roll { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public virtual ICollection<Plate> Plates { get; set; }
        public virtual ICollection<Capatcy> Capatcies { get; set; }
    }
}