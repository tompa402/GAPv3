using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class ReportDetailsViewModel
    {
        public int ReportId { get; set; }

        public string Name { get; set; }

        public int? NormId { get; set; }

        public string NormName { get; set; }

        public string OrganisationName { get; set; }

        public List<User> AssignedUsers { get; set; }

        public List<ReportValue> ReportValues { get; set; }
    }
}