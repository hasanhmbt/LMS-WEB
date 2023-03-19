using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

[Keyless]
public partial class VwBookCategory
{
    [Column("id")]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    public string CategoryDescription { get; set; } = null!;

    public int? Books { get; set; }
}
