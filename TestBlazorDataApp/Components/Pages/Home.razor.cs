using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;
using TestBlazorDataApp.Data;
using TestBlazorDataApp.Data.Models;
using TestBlazorDataApp.Services;

namespace TestBlazorDataApp.Components.Pages
{
    public class HomeBase : PageBase
    {
        [Parameter]
        public int Param { get; set; }

        public int YourNumber { get; set; }
        public Thing FirstThing { get; set; } = new();
        public bool? SaveSuccess { get; set; }

        protected override void OnInitialized()
        {
            YourNumber = TestService.AddOne(1);
            FirstThing = TestService.GetFirstThing();
        }

        public void OnSave()
        {
            try
            {
                Logger.LogInformation("OnSave");
                TestService.UpdateThing(FirstThing);
                SaveSuccess = true;
            }
            catch (Exception)
            {
                SaveSuccess = false;
            }
        }

        public async Task OnTestJs()
        {
            // https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-8.0
            await JsModule.InvokeVoidAsync("Home.test"); // Call JS function in C#
        }
    }
}