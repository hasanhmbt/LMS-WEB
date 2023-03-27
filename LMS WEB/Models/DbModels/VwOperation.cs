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
    public string? Book { get; set; }

    public string Reader { get; set; } = null!;

    [StringLength(256)]
    public string? UserName { get; set; }

    public bool? AcceptStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OperationDate { get; set; }
}
