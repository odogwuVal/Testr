using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.Base
{
   public  class CycleBase
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Cycle Name is required")]
        public string CycleName { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Description  is required")]
        public string Description { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Date open is required")]
        public DateTime DateOpened { get; set; }

        [Required(ErrorMessage = "Date closed is required")]
        public DateTime DateClosed { get; set; }

        
    }
}
