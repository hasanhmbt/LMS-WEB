using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class ContactViewModel
    {

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Message { get; set; }
        [StringLength(100)]
        public string? PhoneNum { get; set; }


    }
}
