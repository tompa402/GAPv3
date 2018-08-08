using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAPv3.Models
{
    public class Norm
    {
        public int NormId { get; set; }

        [Display(Name = "Naziv norme")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NormItem> NormItem { get; set; }
        public virtual ICollection<Report> Report { get; set; }
    }
}