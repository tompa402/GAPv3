using System.ComponentModel.DataAnnotations;

namespace GAPv3.ViewModels
{
    public class NormViewModel
    {
        public int NormId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Dodatne kontrole")]
        public bool HaveAdditionalItems { get; set; }
    }
}