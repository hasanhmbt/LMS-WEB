using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class AddOrEditCategoryViewModel
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage ="Write a category name!")]
        [StringLength(100)]
        public string? Name { get; set; }

        public string CategoryDescription { get; set; } = null!;


    }
}
