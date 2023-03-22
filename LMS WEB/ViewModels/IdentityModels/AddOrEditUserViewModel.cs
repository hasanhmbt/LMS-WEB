using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels.IdentityModels
{
    public class AddOrEditUserViewModel
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
        public string? RoleId { get; set; }

        public string? ImagePath { get; set; }
        public IFormFile? UserImage { get; set; }

    }
}
