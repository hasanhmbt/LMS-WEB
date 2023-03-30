﻿using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]

        public string? Message { get; set; }


    }
}
