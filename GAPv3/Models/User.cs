using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAPv3.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "JMBAG")]
        public int JMBAG { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public bool IsActive { get; set; }

        public User()
        {
            Created = DateTime.Now;
        }

        public ICollection<UserRole> UserRoles { get; set; }

        public int? OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        
    }
}