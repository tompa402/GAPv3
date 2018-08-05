using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using GAPv3.Models;

namespace GAPv3.DAL
{
    public class GAPv3Context : DbContext
    {
        public GAPv3Context() : base("GAPv3")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Norm> Norms { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
