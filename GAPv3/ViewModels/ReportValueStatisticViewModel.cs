﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAPv3.Models;
using Highsoft.Web.Mvc.Charts;

namespace GAPv3.ViewModels
{
    public class ReportValueStatisticViewModel
    {
        public virtual NormItem NormItem { get; set; }

        public int? StatusId { get; set; }

        [Display(Name = "Potpuno implementiran")]
        public int FullImpl { get; set; }

        [Display(Name = "Djelomice implementiran")]
        public int PartImpl { get; set; }

        [Display(Name = "Nije implementiran")]
        public int NoImpl { get; set; }

        public int? FullImplCount { get; set; }
        public int? PartImplCount { get; set; }
        public int? NoImplCount { get; set; }

        // These properties are used for coloring if they are not Items in ReportValues
        public string ColorFullImpl => FullImplCount > 0 ? "blue" : "";
        public string ColorPartImpl => PartImplCount > 0 ? "orange" : "";
        public string ColorNoImpl => NoImplCount > 0 ? "red" : "";

        // These properties are used for placing icon for Item ReportValues
        public string IconFullImpl => StatusId == 1 ? "fa fa-check fa-lg fa-green" : "fa fa-times fa-lg fa-red";
        public string IconPartImpl => StatusId == 2 ? "fa fa-check fa-lg fa-green" : "fa fa-times fa-lg fa-red";
        public string IconNoImpl => StatusId == 3 ? "fa fa-check fa-lg fa-green" : "fa fa-times fa-lg fa-red";

        public virtual List<ReportValueStatisticViewModel> Children { get; set; }

        public Highcharts Chart { get; set; }

        public ReportValueStatisticViewModel()
        {
            this.Children = new List<ReportValueStatisticViewModel>();
        }
    }
}