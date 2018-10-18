using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class NormItemViewModel
    {
        public int NormItemId { get; set; }
        [Display(Name = "Opis zahtjeva")]
        public string Name { get; set; }
        public bool IsItem { get; set; }
        [Display(Name = "Klauzula")]
        public int Order { get; set; }

        public int NormId { get; set; }
        public Norm Norm { get; set; }

        public int? ParentId { get; set; }
        public NormItem Parent { get; set; }

        public string Level { get; set; }
        public string Target { get; set; }
    }
}