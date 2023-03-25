using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class ReaderImage
{
    [Key]
    public int Id { get; set; }

    public int? ReaderId { get; set; }

    [StringLength(300)]
    public string? FileName { get; set; }

    [StringLength(300)]
    public string? FilePath { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [ForeignKey("ReaderId")]
    [InverseProperty("ReaderImages")]
    public virtual Reader? Reader { get; set; }
}
