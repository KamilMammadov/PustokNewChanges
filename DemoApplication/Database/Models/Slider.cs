using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Slider : BaseEntity<int>, IAuditable
    {
        public string MainTitle { get; set; }
        public string Content { get; set; }
        public string Backgroundİmage { get; set; }

        public string BackgroundİmageInFileSystem { get; set; }
        public string Button { get; set; }
        public string ButtonRedirectUrl { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
