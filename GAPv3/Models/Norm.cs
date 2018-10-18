﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAPv3.Models
{
    public class Norm
    {
        public int NormId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // TODO: remove virtual from properties. Test application after that!
        // TODO: implement isActive.
        public virtual ICollection<NormItem> NormItem { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<ReportValueAdditionalItem> ReportValueAdditionalItem { get; set; }
    }
}