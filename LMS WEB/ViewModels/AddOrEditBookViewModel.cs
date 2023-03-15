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
        [StringLength(6)]
        public string? Code { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public int? AuthorId { get; set; }
        [Required]
        public int? BookQuantity { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public List<IFormFile>? FormFiles { get; set; }

    }
}
