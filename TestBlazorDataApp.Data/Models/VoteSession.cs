using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace TestBlazorDataApp.Data
{
    public class VoteSession : Entity
    {
        public VoteTopic VoteTopic { get; set; }
        public long? CurrentHangoutParticipantId { get; set; }

        [Required]
        [ForeignKey(nameof(Hangout))]
        public long HangoutId { get; set; }


        public virtual Hangout Hangout { get; set; }        
        public virtual HashSet<Vote> Votes { get; set; }
            = new HashSet<Vote>();
    }

    public partial class Configurator
    {
        public void VoteSession()
        {
        }
    }
}
