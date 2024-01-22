using MarialaTemplate.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarialaTemplate.Models
{
    public class Team:BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
