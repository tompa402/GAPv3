using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAPv3.Migrations;
using GAPv3.Service;

namespace GAPv3.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        [Display(Name = "Naziv izvještaja")]
        [Required(ErrorMessage = "Nedostaje naziv izvještaja")]
        [StringLength(160)]
        public string Name { get; set; }

        public int NormId { get; set; }
        public Norm Norm { get; set; }

        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        public List<ReportValue> ReportValues { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public Report()
        {
            Created = DateTime.Now;
        }
    }
}