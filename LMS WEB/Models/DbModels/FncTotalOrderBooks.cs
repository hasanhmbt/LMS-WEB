using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels
{

    [Keyless]

    public class FncTotalOrderBooks
    {
        public string Month { get; set; }
        public int Total { get; set; }

    }
}
