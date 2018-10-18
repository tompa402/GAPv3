using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.ViewModels
{
    public class NormItemFormViewModel
    {
        public int NormItemId { get; set; }
        [Display(Name = "Opis zahtjeva")]
        [DataType(DataType.MultilineText)]
        public string Name { get; set; }
        public bool IsItem { get; set; }
        [Display(Name = "Klauzula")]
        public int Order { get; set; }
        public int NormId { get; set; }
        public string NormName { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }

        public NormItemFormViewModel(int normId, int? parentId)
        {
            NormId = normId;
            ParentId = parentId;
        }
    }
}