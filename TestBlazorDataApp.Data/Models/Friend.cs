using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace TestBlazorDataApp.Data
{
    public class Friend : Entity
    {
        public FriendStatus FriendStatus { get; set; }

        [Required]
        [ForeignKey(nameof(UserA))]
        public long UserAId { get; set; }
        [Required]
        [ForeignKey(nameof(UserB))]
        public long UserBId { get; set; }


        public virtual User UserA { get; set; }
        public virtual User UserB { get; set; }
    }

    public partial class Configurator
    {
        public void Friend()
        {
        }
    }
}