using AutoMapper;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public HolidayService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //To Get all holiday details
        public List<HolidayDto> GetHolidays()
        {
            try
            {
                var data = _dbContext.Holidays.OrderBy(x => x.HolidayDate).ToList();

                return _mapper.Map<List<HolidayDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Add new holiday record
        public void AddHoliday(HolidayDto holiday)
        {
            if (_dbContext.Holidays.Any(x => x.HolidayDate == DateOnly.FromDateTime(holiday.HolidayDate)))
            {
                throw new Exception("The holiday on that day has already been entered!");
            }

            try
            {
                var data = _mapper.Map<Holiday>(holiday);

                _dbContext.Holidays.Add(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Update the records holiday
        public void UpdateHoliday(HolidayDto holiday)
        {
            if (holiday is null)
            {
                throw new ArgumentNullException("Parameter 'holiday' is null.");
            }

            // TODO: check existence
            try
            {
                var data = _dbContext.Holidays.Single(x => x.Id == holiday.Id);

                _mapper.Map(holiday, data);

                _dbContext.Holidays.Update(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

        //Get the details of a particular holiday
        public HolidayDto GetHoliday(int id)
        {   
            try
            {
                var data = _dbContext.Holidays.Find(id);

                if (data != null)
                {
                    return _mapper.Map<HolidayDto>(data);
                }
                else
                {
                    throw new KeyNotFoundException($"Holiday with id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Delete the record of a particular holiday
        public void DeleteHoliday(int id)
        {
            try
            {
                var data = _dbContext.Holidays.Find(id);
                if (data != null)
                {
                    _dbContext.Holidays.Remove(data);

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}

