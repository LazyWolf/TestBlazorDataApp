#nullable disable
using TestBlazorDataApp.Data.Enums;

namespace TestBlazorDataApp.Data.Models
{
    public class Thing : Entity
    {
        public string Text { get; set; }
        public ThingStatus ThingStatus { get; set; }
    }
}
