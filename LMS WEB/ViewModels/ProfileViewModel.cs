using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModel
{
    public class ProfileViewModel
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

        public string? Role { get; set; }

        public string? ImagePath { get; set; }
        public IFormFile? UserImage { get; set; }

    }
}
