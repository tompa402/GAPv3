﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;

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

	    //public int? ControlId { get; set; }
	    //[Display(Name = "Odabir kontrole")]
	    //public Control Control { get; set; }

	    //public int? ReasonId { get; set; }
	    //[Display(Name = "Razlog odabira")]
	    //public Reason Reason { get; set; }

	    [Display(Name = "Napomena")]
	    public string Note { get; set; }

        // public List<ReportAdditionalItem> AdditionalItems { get; set; }

        // property is virtual because of lazy loading. At this state we don't need to use include(select) in query.
        public virtual List<ReportValue> Children { get; set; }

        public ReportValue()
	    {
	        this.Children = new List<ReportValue>();
	    }
    }
}