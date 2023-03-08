using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels;

public partial class Reader
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? PhoneNum { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [Required]
    public bool? Status { get; set; }

    [StringLength(100)]
    public string? Password { get; set; }
}
