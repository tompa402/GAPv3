using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.DAL
{
    // public class GAPv3ContextInitializer : DropCreateDatabaseIfModelChanges<GAPv3Context>
    public class GAPv3ContextInitializer : DropCreateDatabaseAlways<GAPv3Context>
    {
        protected override void Seed(GAPv3Context context)
        {
            // loading default values
            context.Norms.Add(new Norm()
            {
                Name = "HRN ISO/IEC 27001:2013",
                Description = "Informacijska tehnologija - Sigurnosne tehnike - Sustavi upravljanja informacijskom sigurnošću - Zahtjevi"
            });
            context.Norms.Add(new Norm()
            {
                Name = "HRN ISO/IEC 27002:2013",
                Description = "Information technology – Security techniques – Code of practice for information security controls"
            });

            context.Organisations.Add(new Organisation() { OrganisationId = 1, Name = "Test organizacija" });
            context.Organisations.Add(new Organisation() { OrganisationId = 2, Name = "Druga test organizacija" });

            context.Reports.Add(new Report() { Name = "Custom report", NormId = 1, OrganisationId = 1 });
            context.Reports.Add(new Report() { Name = "Custom report 2", NormId = 2, OrganisationId = 2 });

            context.SaveChanges();
        }
    }
}