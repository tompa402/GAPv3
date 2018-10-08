using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GAPv3.Migrations;

namespace GAPv3.Models
{
    public class NormItem
    {
        public int NormItemId { get; set; }
        [Display(Name = "Opis zahtjeva")]
        public string Name { get; set; }
        public bool IsItem { get; set; }
        [Display(Name = "Klauzula")]
        public int Order { get; set; }

        public int NormId { get; set; }
        public virtual Norm Norm { get; set; }

        public int? ParentId { get; set; }
        public virtual NormItem Parent { get; set; }
        [ForeignKey("ParentId")]
        public virtual IList<NormItem> Children { get; set; }

        [ForeignKey("NormItemId")]
        public IList<ReportValue> ReportValue { get; set; }
    }
}