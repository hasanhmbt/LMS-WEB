using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class AddOrEditBookViewModel
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public string? Author { get; set; }
        [Required]
        public int? Count { get; set; }

        [Required]
        public bool? Status { get; set; }
        [Required]

        public int? CategoryId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Required]
        [StringLength(6)]
        public string? Code { get; set; }
        public List<IFormFile>? FormFiles { get; set; }

    }
}
