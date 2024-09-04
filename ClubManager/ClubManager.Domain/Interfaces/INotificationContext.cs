namespace ClubManager.Domain.Interfaces
{
    public interface INotificationContext
    {
        public void AddNotification(string error, string message);
        public bool HasNotifications();
    }
}
