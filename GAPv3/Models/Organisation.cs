using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAPv3.Models
{
    public class Organisation
    {
        public int OrganisationId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno poslje")]
        [Display(Name = "Naziv organizacije")]
        public string Name { get; set; }

        public virtual ICollection<Report> Report { get; set; }
    }
}