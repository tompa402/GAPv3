using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class ReportCardViewModel
    {
        public IEnumerable<Norm> Norms { get; set; }

        public IEnumerable<ReportViewModel> ReportViewModels { get; set; }
    }
}