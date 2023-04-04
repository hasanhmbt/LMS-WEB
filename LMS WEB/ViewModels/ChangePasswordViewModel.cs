using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "One time password is incorrect")]
        [DataType(DataType.Password)]
        public string OneTimePassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and confirmation password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
