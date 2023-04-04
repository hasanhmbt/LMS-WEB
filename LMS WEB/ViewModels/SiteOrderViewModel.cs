using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_WEB.ViewModels
{
    public class SiteOrderViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }

        public int? BookId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate {get; set;}
    }
}
