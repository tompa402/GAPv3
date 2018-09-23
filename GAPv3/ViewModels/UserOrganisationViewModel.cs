using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class UserOrganisationViewModel
    {
        public Organisation Organisation { get; set; }
        
        public int UserId { get; set; }
        public IEnumerable<SelectListItem> UsersList { set; get; }
        [Display(Name = "Članovi organizacije")]
        public List<int> SelectedUsers { set; get; }

        public UserOrganisationViewModel()
        {
            SelectedUsers = new List<int>();
        }
    }
}