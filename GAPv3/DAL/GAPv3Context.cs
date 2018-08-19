using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using GAPv3.Migrations;
using GAPv3.Models;
using Control = GAPv3.Models.Control;

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
        public DbSet<NormItem> NormItems { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ReportValue> ReportValues { get; set; }
        public DbSet<Control> Controls { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<ReportValueAdditionalItem> ReportValueAdditionalItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
