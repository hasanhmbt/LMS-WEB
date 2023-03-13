using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

[Keyless]
public partial class VwBook
{
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(6)]
    public string? Code { get; set; }

    [StringLength(200)]
    public string? Author { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    public int? CategoryId { get; set; }

    public int? BookQuantity { get; set; }

    public bool Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }
}
