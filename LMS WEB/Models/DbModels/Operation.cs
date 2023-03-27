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

    public int? BookId { get; set; }

    public int? ReaderId { get; set; }

    [StringLength(300)]
    public string? UserId { get; set; }

    public bool? AcceptStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OperationDate { get; set; }

    public int? OrderedBooks { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Operations")]
    public virtual Book? Book { get; set; }

    [ForeignKey("ReaderId")]
    [InverseProperty("Operations")]
    public virtual Reader? Reader { get; set; }
}
