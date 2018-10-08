using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class ReportFormViewModel
    {
        public int ReportId { get; set; }

        public string Name { get; set; }

        public int NormId { get; set; }
        public Norm Norm { get; set; }

        public int OrganisationId { get; set; }

        public List<ReportValueFormViewModel> ReportValues { get; set; } 

        public IEnumerable<Organisation> Organisations { get; set; }
    }
}