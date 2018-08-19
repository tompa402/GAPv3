using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.Models
{
    public class Norm
    {
        public int NormId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NormItem> NormItem { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<ReportValueAdditionalItem> ReportValueAdditionalItem { get; set; }
    }
}