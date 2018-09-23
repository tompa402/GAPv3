using System.Collections.Generic;
using System.Web.Mvc;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class UserOrganisationViewModel
    {
        public Organisation organisation = new Organisation();

        public int UserId { get; set; }
        public IEnumerable<SelectListItem> UsersList { set; get; }
        public List<int> SelectedUsers { set; get; }
    }
}