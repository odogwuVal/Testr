﻿using System.ComponentModel.DataAnnotations;
using Testr.Domain.DTOs;

namespace Testr.Domain.Interfaces
{
    public class CandidateRegistration : CandidateBase
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}