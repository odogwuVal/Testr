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
       [Required]
        public string CycleName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime DateOpened { get; set; }
        [Required]
        public DateTime DateClosed { get; set; }
        [Required]
        public DateTime LastModified { get; set; }
    }
}
