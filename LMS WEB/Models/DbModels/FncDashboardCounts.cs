using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels
{

    [Keyless]
    public class FncDashboardCounts
    {
        public int? bookCategories { get; set; }
        public int? allBooks { get; set; }
        public int? allReaders { get; set; }
        public int? allAuthors { get; set; }
        public int? orederedBooks { get; set; }

    }
}
