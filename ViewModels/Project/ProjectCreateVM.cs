using System.ComponentModel.DataAnnotations.Schema;

namespace MarialaTemplate.ViewModels.Project
{
    public class ProjectCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
