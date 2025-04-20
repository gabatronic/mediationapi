namespace mediation.mediations.Application;

public interface INotificationService<T> where T : class
{
    public Task SendMessage(T message);
}