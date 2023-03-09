using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class BookCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    public bool? Status { get; set; }

    [InverseProperty("BookCategory")]
    public virtual ICollection<Book> Books { get;  }= new List<Book>();
}
