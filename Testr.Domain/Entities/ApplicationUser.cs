﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Candidate Candidate { get; set; }
    }
}
