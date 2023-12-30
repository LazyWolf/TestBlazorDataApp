using Microsoft.AspNetCore.Components;
using TestBlazorDataApp.Services;

namespace TestBlazorDataApp.Components
{
    public class PageBase : ComponentBase
    {
        [Inject]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected ILogger<PageBase> Logger { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Inject]
        protected TestService TestService { get; set; } = new();
    }
}
