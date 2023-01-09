namespace DemoApplication.Areas.Client.ViewModels.Authentication
{
    public class EmailActiveteViewModel
    {
        public string Email { get; set; }
        public EmailActiveteViewModel(string email)
        {
            Email = email;
        }
    }
}
