using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Admin.ViewModels.Slider
{
    public class AddViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string MainTitle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public IFormFile Backgroundİmage { get; set; }
        public string? BackgroundİmageUrl { get; set; }
        [Required]
        public string Button { get; set; }
        [Required]
        public string ButtonRedirectUrl { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
