using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.Models.DbModels
{

    [Keyless]
    public class FncMostOrderedBooks
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public int? AuthorId { get; set; }

        public int? Count { get; set; }

        public string Author { get; set; } = null!;

        public string? Category { get; set; }

        public int? CategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Remainder { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

    }
}
