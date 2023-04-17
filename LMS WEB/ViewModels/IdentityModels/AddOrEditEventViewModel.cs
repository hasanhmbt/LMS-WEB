using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels.IdentityModels
{
    public class AddOrEditEventViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="You must enter a envent name")]
        [StringLength(150)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must enter a envent description")]
        public string? EventDescription { get; set; }


        [Required(ErrorMessage = "You must enter a envent date")]
        [Column(TypeName = "datetime")]
        public DateTime? EventTime { get; set; }
    }
}
