using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GAPv3.Models
{
    public class ReportValue
    {
        [Key, Column(Order = 0)]
        public int ReportId { get; set; }

        [Key, Column(Order = 1)]
        public int NormItemId { get; set; }
        public NormItem NormItem { get; set; }

        public int? StatusId { get; set; }
        [Display(Name = "Trenutni status")]
        public Status Status { get; set; }

        [Display(Name = "Napomena")]
        public string Note { get; set; }

        public List<ReportValue> Children { get; set; }

        public ReportValue()
        {
            this.Children = new List<ReportValue>();
        }
    }
}