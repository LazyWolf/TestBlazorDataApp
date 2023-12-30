#nullable disable
namespace TestBlazorDataApp.Data
{
    public class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
            = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
            = DateTime.Now;
        public string UpdatedBy { get; set; }
    }
}