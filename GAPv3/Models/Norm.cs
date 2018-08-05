using System.ComponentModel.DataAnnotations;

namespace GAPv3.Models
{
    public class Norm
    {
        public int NormId { get; set; }

        [Display(Name = "Naziv norme")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}