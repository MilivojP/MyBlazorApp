using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IHolidayService
    {
        public List<HolidayDto> GetHolidays();

        public void AddHoliday(HolidayDto holiday);

        public void UpdateHoliday(HolidayDto holiday);

        public HolidayDto GetHoliday (int Id);

        public void DeleteHoliday(int Id);
    }
}
