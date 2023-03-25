using LMS_WEB.Models.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.ViewModels
{
    public class AddOrEditOperationViewModel
    {


        [Key]
        public int Id { get; set; }

        public int? BookId { get; set; }
        [Required]
        public int? ReaderId { get; set; }

        [StringLength(300)]
        public string? UserId { get; set; }

        public bool? AcceptStatus { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OperationDate { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty("Operations")]
        public virtual Book? Book { get; set; }

        [ForeignKey("ReaderId")]
        [InverseProperty("Operations")]
        public virtual Reader? Reader { get; set; }


    }
}
