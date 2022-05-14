using Otopark.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Otopark.Models.DataContext
{
    public partial class Context :DbContext
    {
        public Context() : base("Otopark")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Plate> Plates { get; set; }
        public virtual DbSet<Capatcy> Capatcies { get; set; }
    }
}