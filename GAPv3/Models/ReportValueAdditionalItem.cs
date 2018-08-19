using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAPv3.Models
{
    public class ReportValueAdditionalItem
    {
        [Key, Column(Order = 0)]
        public int NormId { get; set; }

        [Key, Column(Order = 1)]
        public bool HaveReason { get; set; }

        [Key, Column(Order = 2)]
        public bool HaveControl { get; set; }
    }
}