using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Month
{
    [Key]
    public int Id { get; set; }

    public int? Value { get; set; }

    [StringLength(10)]
    public string? Name { get; set; }
}
