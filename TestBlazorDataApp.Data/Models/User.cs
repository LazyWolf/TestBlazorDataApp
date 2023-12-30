#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBlazorDataApp.Data
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }


        [InverseProperty(nameof(Friend.UserA))]
        public virtual HashSet<Friend> FriendAs { get; set; }
            = new HashSet<Friend>();
        [InverseProperty(nameof(Friend.UserB))]
        public virtual HashSet<Friend> FriendBs { get; set; }
            = new HashSet<Friend>();
        public virtual HashSet<UserSettings> UserSettings { get; set; }
            = new HashSet<UserSettings>();
        public virtual HashSet<HangoutParticipant> ParticipatedHangouts { get; set; }
            = new HashSet<HangoutParticipant>();
        public virtual HashSet<Notification> Notifications { get; set; }
            = new HashSet<Notification>();
    }

    public partial class Configurator
    {
        public void User()
        {
        }
    }
}
