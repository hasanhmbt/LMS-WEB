using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.Models.IdentityModels
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? ImagePath { get; set; }
        public bool ChangePassword { get; set; }
    }
}
