using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace TestBlazorDataApp.Data
{
    public class Vote : Entity
    {
        public string ItemId { get; set; }
        public VoteState VoteState { get; set; }

        [Required]
        [ForeignKey(nameof(VoteSession))]
        public long VoteSessionId { get; set; }
        [Required]
        [ForeignKey(nameof(HangoutParticipant))]
        public long HangoutParticipantId { get; set; }


        public virtual VoteSession VoteSession { get; set; }
        public virtual HangoutParticipant HangoutParticipant { get; set; }
    }

    public partial class Configurator
    {
        public void Vote()
        {
        }
    }
}
