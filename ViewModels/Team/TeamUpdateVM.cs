using System.ComponentModel.DataAnnotations.Schema;

namespace MarialaTemplate.ViewModels.Team
{
    public class TeamUpdateVM
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
