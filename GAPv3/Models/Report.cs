﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAPv3.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        [Display(Name = "Naziv izvještaja")]
        public string Name { get; set; }

        public int NormId { get; set; }
        public virtual Norm Norm { get; set; }

        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}