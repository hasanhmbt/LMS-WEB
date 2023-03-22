using System.ComponentModel.DataAnnotations;

namespace LMS_WEB.Models.IdentityModels
{
    public class VwRole
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public int? UserCount { get; set; }
    }
}
