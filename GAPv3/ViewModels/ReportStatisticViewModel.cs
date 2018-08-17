using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class ReportStatisticViewModel
    {
        public int ReportId { get; set; }
        [Display(Name = "Naziv izvještaja")]
        public string Name { get; set; }

        public virtual Norm Norm { get; set; }

        public virtual Organisation Organisation { get; set; }

        [Display(Name = "Popunjenost")]
        public int Popunjenost { get; set; }

        public virtual List<ReportValueStatisticViewModel> ReportValues { get; set; }
    }
}