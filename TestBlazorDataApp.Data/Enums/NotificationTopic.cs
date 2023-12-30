namespace TestBlazorDataApp.Data
{
    public enum NotificationTopic
    {
        Hangout = 0,
        HangoutCreated = 1,
        HangoutUpdated = 2,
        HangoutFinalized = 3,

        VoteSession = 100,
        VoteSessionStarted = 101,
        VoteSessionUpdated = 102,
        VoteSessionCompleted = 103,

        Friend = 200,
        FriendRequested = 201,
        FriendAccepted = 202,
        FriendRejected = 203,
    }
}
