namespace OrderNow.API.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}