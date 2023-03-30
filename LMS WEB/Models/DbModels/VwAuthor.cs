using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

[Keyless]
public partial class VwAuthor
{
    public int Id { get; set; }

    [StringLength(150)]
    public string? Name { get; set; }

    [StringLength(150)]
    public string? Surname { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Birthdate { get; set; }

    public int? Books { get; set; }

    public string? Description { get; set; }

    public string? ImagePath { get; set; }
}
