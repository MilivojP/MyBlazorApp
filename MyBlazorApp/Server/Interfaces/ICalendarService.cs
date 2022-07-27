namespace MyBlazorApp.Server.Interfaces
{
    public interface ICalendarService
    {
        bool IsOverlapping(DateOnly dateFrom, DateOnly dateTo);
    }
}
