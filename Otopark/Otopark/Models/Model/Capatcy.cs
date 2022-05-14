using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otopark.Models.Model
{
    public partial class Capatcy
    {
        [Key]
        public int CapactyId { get; set; }
        public int Capacty { get; set; }
        public float Paid  { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }

    }
}