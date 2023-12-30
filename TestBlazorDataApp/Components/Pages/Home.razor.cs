using Microsoft.AspNetCore.Components;
using TestBlazorDataApp.Data;
using TestBlazorDataApp.Services;

namespace TestBlazorDataApp.Components.Pages
{
    public class HomeBase : PageBase
    {
        [Parameter]
        public int Param { get; set; }

        public int YourNumber { get; set; }
        public User FirstUser { get; set; } = new();
        public bool? SaveSuccess { get; set; }

        protected override void OnInitialized()
        {
            YourNumber = TestService.AddOne(1);
            FirstUser = TestService.GetFirstUser();
        }

        public void OnSave()
        {
            try
            {
                Logger.LogInformation("Hello World");
                TestService.UpdateUser(FirstUser);
                SaveSuccess = true;
            }
            catch (Exception)
            {
                SaveSuccess = false;
            }
        }
    }
}
