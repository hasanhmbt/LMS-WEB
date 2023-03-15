using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class AuthorImage
{
    [Key]
    public int Id { get; set; }

    public int? AuthorId { get; set; }

    [StringLength(300)]
    public string? FileName { get; set; }

    [StringLength(300)]
    public string? FilePaht { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("AuthorImages")]
    public virtual Author? Author { get; set; }
}
