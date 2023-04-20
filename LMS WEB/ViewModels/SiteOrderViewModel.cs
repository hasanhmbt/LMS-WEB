using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_WEB.ViewModels
{
    public class SiteOrderViewModel
    {
        [Key]
        public int? Id { get; set; }

        [StringLength(100)]
        public string? BookName { get; set; }

        public bool? AcceptStatus { get; set; }

        [StringLength(256)]
        public string? UserName { get; set; }

        [Column("userId")]
        [StringLength(450)]
        public string? UserId { get; set; }

        public int? BookId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
    }
}
