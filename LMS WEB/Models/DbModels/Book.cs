using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Book
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(200)]
    public string? Author { get; set; }

    public int? Count { get; set; }

    [Required]
    public bool? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }
}
