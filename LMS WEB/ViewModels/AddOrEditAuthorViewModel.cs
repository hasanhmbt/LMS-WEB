using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class AddOrEditAuthorViewModel
    {

        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Write a author name!")]
        [StringLength(150)]
        public string? Name { get; set; }

        [Required(ErrorMessage = " Write a author surname!")]
        [StringLength(150)]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Choose author born date!")]
        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        public int? Books { get; set; }

        [Required(ErrorMessage = "Write description for author!")]

        public string? Description { get; set; }

        public List<IFormFile>? FormFiles { get; set; }

    }
}
