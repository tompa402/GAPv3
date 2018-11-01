using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class UserOrganisationCardViewModel
    {
        public int OrganisationId { get; set; }

        [Display(Name = "Naziv")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Članovi")]
        public List<User> Users { get; set; }
    }
}