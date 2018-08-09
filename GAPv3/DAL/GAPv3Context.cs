using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<NormItem> NormItems { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ReportValue> ReportValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: remove after enabling DATA MIGRATIONS --> in add migration we will disable delete on cascade.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ReportValue>().HasKey(q =>
                new {
                    q.ReportId,
                    q.NormItemId
                });

            // Relationships
            modelBuilder.Entity<ReportValue>()
                .HasRequired(t => t.Report)
                .WithMany(t => t.ReportValue)
                .HasForeignKey(t => t.ReportId);

            modelBuilder.Entity<ReportValue>()
                .HasRequired(t => t.NormItem)
                .WithMany(t => t.ReportValue)
                .HasForeignKey(t => t.NormItemId);
        }
    }
}
