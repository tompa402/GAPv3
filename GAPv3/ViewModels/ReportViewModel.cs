using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class ReportViewModel
    {
        public int ReportId { get; set; }
        public string Name { get; set; }

        public int NormId { get; set; }
        public virtual Norm Norm { get; set; }

        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }

        [Display(Name = "Popunjenost")]
        public int Popunjenost { get; set; }

        public List<ReportValue> ReportValues { get; set; }

        public ReportViewModel()
        {
            this.ReportValues = new List<ReportValue>();
        }
    }
}