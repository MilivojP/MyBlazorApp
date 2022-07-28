using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Interfaces;

namespace MyBlazorApp.Server.Services
{
    public class CalendarService : ICalendarService
    {
        readonly DatabaseContext _dbContext;
        

        public bool IsOverlapping(DateOnly dateFrom, DateOnly dateTo )
        {
            
            //TODO check WorkTime
            if (_dbContext.WorkTimes.Any(x => x.Day >= dateFrom && x.Day < dateTo))
            {
               //return true;
                IsOverlapping(dateFrom, dateTo);
            }
            else

                throw new NotImplementedException();

            //TODO check SickLeave
            if (_dbContext.SickLeaves.Any(x => x.StartDate >= dateFrom && x.EndDate <= dateTo))
            {
                IsOverlapping(dateFrom, dateTo);
            }
            else
                
            throw new NotImplementedException();

            //TODO check Vacation
            if (_dbContext.Vacations.Any(x => x.DateFrom>= dateFrom && x.DateTo<= dateTo))
            {
                IsOverlapping(dateFrom, dateTo);
            }

            throw new NotImplementedException();
        }
    }
}
