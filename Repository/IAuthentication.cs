namespace EffortTracker.Repository
{
    public interface IAuthentication
    {
        string AuthenticationUser(int associate_id, string password);
    }
}
