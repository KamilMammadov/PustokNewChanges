namespace DemoApplication.Areas.Client.ViewModels.Home.Index
{
    public class SliderListViewModel
    {
        public SliderListViewModel(int id, string mainTitle, string content, string button, string buttonRedirectUrl, string backGroundImageUrl, int order)
        {
            Id = id;
            MainTitle = mainTitle;
            Content = content;
            Button = button;
            ButtonRedirectUrl = buttonRedirectUrl;
            BackGroundImageUrl = backGroundImageUrl;
            Order = order;
        }

        public int Id { get; set; }
        public string MainTitle { get; set; }
        public string Content { get; set; }
        public string Button { get; set; }
        public string ButtonRedirectUrl { get; set; }
        public string BackGroundImageUrl { get; set; }
        public int Order { get; set; }
        public SliderListViewModel()
        {
        }
    }
}
