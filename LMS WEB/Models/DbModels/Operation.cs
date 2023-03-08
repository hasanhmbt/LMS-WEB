using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Operation
{
    [Key]
    public int Id { get; set; }

    public int? ReaderId { get; set; }

    public int? BookId { get; set; }

    public string? UserId { get; set; }

    public bool? EmailStatus { get; set; }

    public bool? AcceptStatus { get; set; }

    public bool Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OperationDate { get; set; }
}
