using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.Base;

namespace Testr.Domain.Entities
{
    public class Cycle: CycleBase
    {
        [Key]
        [Required]
        public long CycleId { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

    }
}

