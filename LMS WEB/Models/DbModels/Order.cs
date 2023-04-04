using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string? UserId { get; set; }

    public int? BookId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }
}
