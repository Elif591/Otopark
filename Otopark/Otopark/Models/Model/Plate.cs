using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace Otopark.Models.Model
{
    public partial class Plate
    {

        [Key]
        public int Plateid { get; set; }
        public String PlateName { get; set; }
        public DateTime? Login { get; set; }
        
        public DateTime? Logout { get; set; }
        public float? Price { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}