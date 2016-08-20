﻿using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.WebApi.Models
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}