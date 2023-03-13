using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class BookImage
{
    [Key]
    public int Id { get; set; }

    public int? BookId { get; set; }

    [StringLength(300)]
    public string? FileName { get; set; }

    [StringLength(300)]
    public string? FilePath { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("BookImages")]
    public virtual Book? Book { get; set; }
}
