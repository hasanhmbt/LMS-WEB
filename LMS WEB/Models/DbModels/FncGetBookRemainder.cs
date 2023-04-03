using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Models.DbModels
{
    [Keyless]
    public class FncGetBookRemainder
    {

        public int Id { get; set; }

        public int? Remainder { get; set; }


    }
}
