using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAPv3.Models
{
    public class Organisation
    {
        public int OrganisationId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje.")]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Display(Name = "Vlasništvo organizacije")]
        public string Ownership { get; set; }

        [Display(Name = "Oblik")] public string Type { get; set; }

        [Display(Name = "Broj zaposlenika")] public string EmployeesNumber { get; set; }

        [Display(Name = "Veličina organizacije")]
        public string Size { get; set; }

        [Display(Name = "Čuvarska služba")] public string GuardService { get; set; }

        [Display(Name = "Video nadzor")] public string VideoSurveillance { get; set; }

        [Display(Name = "Vlastiti poslovni subjekt")]
        public string BuildingPossession { get; set; }

        [Display(Name = "Vlastita IT služba")] public string ITService { get; set; }

        [Display(Name = "Lokacije")] public string Location { get; set; }

        [Display(Name = "Imovina 1")] public string AssetOne { get; set; }

        [Display(Name = "Imovina 2")] public string AssetTwo { get; set; }

        [Display(Name = "Imovina 3")] public string AssetThree { get; set; }

        [Display(Name = "Datum organizacije")] public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public Organisation()
        {
            Created = DateTime.Now;
        }

        public virtual ICollection<Report> Report { get; set; }
    }
}