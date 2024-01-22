using MarialaTemplate.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarialaTemplate.Models
{
    public class Project:BaseEntity
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
