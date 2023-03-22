using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels.IdentityModels
{
    public class AddOrEditRoleViewModel
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
