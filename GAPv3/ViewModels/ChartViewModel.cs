using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAPv3.ViewModels
{
    public class ChartViewModel
    {
        public string TitleParentName { get; set; }

        public List<string> CategoriesNormItemName { get; set; }

        public string ColumnSeriesImplName { get; set; }

        public List<int?> ColumnSeriesImplData { get; set; }

        public string ColumnSeriesPartImplName { get; set; }
        public List<int?> ColumnSeriesPartImplData { get; set; }

        public string ColumnSeriesNoImplName { get; set; }
        public List<int?> ColumnSeriesNoImplData { get; set; }
    }
}