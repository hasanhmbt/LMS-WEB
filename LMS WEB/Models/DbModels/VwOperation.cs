using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

[Keyless]
public partial class VwOperation
{
    public int Id { get; set; }

    [StringLength(100)]
    public string? Reader { get; set; }

    [StringLength(100)]
    public string? Book { get; set; }

    [StringLength(50)]
    public string? User { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OperationDate { get; set; }

    [StringLength(9)]
    public string AcceptStatus { get; set; } = null!;

    public bool Status { get; set; }
}
