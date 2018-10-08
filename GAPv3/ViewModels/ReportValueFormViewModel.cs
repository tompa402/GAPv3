using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class ReportValueFormViewModel
    {
        public ReportValueFormViewModel()
        {
            Children = new List<ReportValueFormViewModel>();
        }

        public int ReportId { get; set; }

        public int NormItemId { get; set; }
        public NormItem NormItem { get; set; }

        public int? StatusId { get; set; }

        public int? ControlId { get; set; }

        public int? ReasonId { get; set; }

        [Display(Name = "Napomena")]
        public string Note { get; set; }

        public List<ReportValueFormViewModel> Children { get; set; }

        public IEnumerable<Control> Controls { get; set; }

        public IEnumerable<Reason> Reasons { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}