using System.ComponentModel.DataAnnotations.Schema;

namespace MarialaTemplate.ViewModels.Project
{
    public class ProjectUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
