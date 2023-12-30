#nullable disable
namespace TestBlazorDataApp.Data
{
    public class Hangout : Entity
    {
        public string Title { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public long? CurrentVoteSessionId { get; set; }


        public virtual HashSet<VoteSession> VoteSessions { get; set; }
            = new HashSet<VoteSession>();
        public virtual HashSet<HangoutParticipant> HangoutParticipants { get; set; }
            = new HashSet<HangoutParticipant>();
    }

    public partial class Configurator
    {
        public void Hangout()
        {
        }
    }
}
