using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace TestBlazorDataApp.Data
{
    public class HangoutParticipant : Entity
    {
        public HangoutParticipantStatus HangoutParticipantStatus { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        [Required]
        [ForeignKey(nameof(Hangout))]
        public long HangoutId { get; set; }

        public virtual User User { get; set; }
        public virtual Hangout Hangout { get; set; }
    }

    public partial class Configurator
    {
        public void HangoutParticipant()
        {
        }
    }
}
