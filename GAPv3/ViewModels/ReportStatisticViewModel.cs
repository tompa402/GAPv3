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

        public string Name { get; set; }

        public int? NormId { get; set; }

        public string NormName { get; set; }

        public string OrganisationName { get; set; }

        public List<User> AssignedUsers { get; set; }

        [Display(Name = "Popunjenost")]
        public int Popunjenost { get; set; }

        public List<ReportValueStatisticViewModel> ReportValues { get; set; }

        public List<ChartViewModel> ChartViewModels { get; set; }
    }
}