using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace TestBlazorDataApp.Data
{
    public class Notification : Entity
    {
        public string Message { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
        public NotificationTopic NotificationTopic { get; set; }
        public long RecordId { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }

    public partial class Configurator
    {
        public void Notification()
        {
        }
    }
}
