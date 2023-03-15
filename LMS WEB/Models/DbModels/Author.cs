using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Author
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    public string? Name { get; set; }

    [StringLength(150)]
    public string? Surname { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Birthdate { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<AuthorImage> AuthorImages { get; } = new List<AuthorImage>();

    [InverseProperty("Author")]
    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
