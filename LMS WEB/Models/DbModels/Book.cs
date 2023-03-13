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

    public int? CategoryId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [StringLength(6)]
    public string? Code { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<BookImage> BookImages { get; } = new List<BookImage>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Books")]
    public virtual BookCategory? Category { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<Operation> Operations { get; } = new List<Operation>();
}
