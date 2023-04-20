using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.Models.DbModels
{

    [Keyless]
    public class FncMostOrderedBooks
    {

        public string Book { get; set; }

        public int OrderCount { get; set; } 

   

    }
}
