using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels
{

    [Keyless]
    public class FncDashboardCounts
    {
        public int? BookCategories { get; set; }
        public int? AllBooks { get; set; }
        public int? AllReaders { get; set; }
        public int? AllAuthors { get; set; }
        public int? OrederedBooks { get; set; }

    }
}
