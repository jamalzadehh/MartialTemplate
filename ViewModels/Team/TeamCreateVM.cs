using System.ComponentModel.DataAnnotations.Schema;

namespace MarialaTemplate.ViewModels.Team
{
    public class TeamCreateVM
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
