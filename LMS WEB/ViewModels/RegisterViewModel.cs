﻿using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class RegisterViewModel
    {

        [Key]
        public string? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string? RoleId { get; set; } = "59d85d04-28f0-47e4-8dec-7068358ab9e2";


    }
}
