using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAPv3.Models
{
    public class HomeMessage
    {
        public int HomeMessageId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public bool IsActive { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public HomeMessage()
        {
            HomeMessageId = 0;
            Created = DateTime.Now;
        }
    }
}