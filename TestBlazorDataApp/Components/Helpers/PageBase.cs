using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TestBlazorDataApp.Services;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace TestBlazorDataApp.Components
{
    public class PageBase : ComponentBase
    {

        [Inject]
        protected ILogger<PageBase> Logger { get; set; }

        [Inject]
        protected TestService TestService { get; set; } = new();

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }
        protected IJSObjectReference JsModule { get; set; }
        protected string JsImport { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                return;
            }

            try
            {
                var jsBehindPath = $"../Components/Pages/{this.GetType().Name}.razor.js? v = {DateTime.Now.Ticks}";
                JsImport = $"<script src='{jsBehindPath}'></script>";
                JsModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import", jsBehindPath);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error loading JS behind for {}", this.GetType().Name);
            }
        }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
