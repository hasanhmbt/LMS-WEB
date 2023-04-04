using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Oreder
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }
}
