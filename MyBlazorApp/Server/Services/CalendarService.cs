using MyBlazorApp.Server.Interfaces;

namespace MyBlazorApp.Server.Services
{
    public class CalendarService : ICalendarService
    {
        public bool IsOverlapping(DateOnly dateFrom, DateOnly dateTo)
        {
            //TODO add dbContext
            //TODO check WorkTime
            //TODO check SickLeave
            //TODO check Vacation
            throw new NotImplementedException();
        }
    }
}
