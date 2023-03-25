using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_WEB.ViewModels
{
    public class AddOrEditReaderViewModel
    {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]

        public string? Name { get; set; }

        [StringLength(100)]
        public string? PhoneNum { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public bool? Status { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        public List<IFormFile>? FormFiles { get; set; }

    }
}
