using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TestBlazorDataApp.Data.Models;
using TestBlazorDataApp.Services;

namespace TestBlazorDataApp.Components.Pages
{
    public class HomeBase : PageBase
    {
        [Parameter]
        public int Param { get; set; }

        public bool? SaveSuccess { get; set; }
        public List<Thing> Things { get; set; } = new();

        protected override void OnInitialized()
        {
            Things = TestService.GetThings().ToList();
            Things.Add(new());
        }

        public void OnSave()
        {
            try
            {
                Logger.LogInformation("OnSave");

                ValidateThing(Things.Last());

                TestService.UpdateThing(Things.Last());

                Things.Add(new());

                SaveSuccess = true;
            }
            catch (Exception)
            {
                SaveSuccess = false;
            }
        }

        public void OnPop()
        {
            Logger.LogInformation("OnSave");

            if (Things.Last().Id > 0)
            {
                TestService.RemoveThing(Things.Last());
            }

            Things.Remove(Things.Last());

            if (Things.Count < 1)
            {
                Things.Add(new());
            }

            SaveSuccess = null;
        }

        private void ValidateThing(Thing thing)
        {
            if (String.IsNullOrWhiteSpace(Things.Last().Text))
            {
                throw new Exception();
            }
        }

        public async Task OnTestJs()
        {
            try
            {
                // https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-8.0
                await JsModule.InvokeVoidAsync("testJs"); // Call JS function in C#
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "OnTestJs error");
            }
        }
    }
}