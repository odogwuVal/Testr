using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.Base;

namespace Testr.Domain.DTOs
{
    public class AdminProfileDTO :AdministratorBase 
    {
        public long AdminId { get; set; }
    }
}
