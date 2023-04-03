using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class AddOrEditBookViewModel
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage ="Write a book code!")]
        [StringLength(6)]
        public string? Code { get; set; }

        [Required(ErrorMessage ="Write a book name!")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Select an Author!")]
        public int? AuthorId { get; set; }
        [Required(ErrorMessage ="Write book quantity!")]
        public int? BookQuantity { get; set; }

        [Required(ErrorMessage ="Select a book category!")]
        public int? CategoryId { get; set; }
         
        public string? Description { get; set; }
        public string? Author { get; set; }

        public string? ImagePath { get; set; }
        public IFormFile? BookImage { get; set; }

    }
}
