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

        public int NormId { get; set; }

        [Display(Name = "Izvještaj")]
        public string Name { get; set; }

        [Display(Name="Norma")]
        public string NormName { get; set; }

        [Display(Name = "Organizacija")]
        public string OrgName { get; set; }

        [Display(Name = "Popunjenost")]
        public int Popunjenost { get; set; }
    }
}