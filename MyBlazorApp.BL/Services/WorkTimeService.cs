using AutoMapper;
using MyBlazorApp.DAL.Data;
using MyBlazorApp.DAL.Entities;
using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Services
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public WorkTimeService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //To Get all worktime details
        public List<WorkTimeDto> GetWorkTimes()
        {
            try
            {
                var data = _dbContext.WorkTimes.OrderBy(x=>x.UserId).ThenByDescending(x=>x.Day).ToList();

                return _mapper.Map<List<WorkTimeDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Add new worktime record
        public void AddWorkTime(NewWorkTimeDto workTime)
        {
            if (_dbContext.WorkTimes.Any(x => x.UserId == workTime.UserId && x.Day == DateOnly.FromDateTime(workTime.Day)))
            {
                throw new Exception("WorkTime with this UserId and tihs Day already exists!");
            }

            try
            {
                var data = _mapper.Map<WorkTime>(workTime);

                _dbContext.WorkTimes.Add(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Update the records worktime
        public void UpdateWorkTime(ExistingWorkTimeDto Day)
        {
            if (Day is null)
            {
                throw new ArgumentNullException("Parameter 'Day' is null.");
            }
            try
            {
                // TODO: get worktime from data store and then update
                var data = _mapper.Map<WorkTime>(Day);

                _dbContext.WorkTimes.Update(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

        //Get the details of a particular worktime
        public ExistingWorkTimeDto GetWorkTime(int id)
        {
            try
            {
                var data = _dbContext.WorkTimes.Find(id);

                if (data != null)
                {
                    return _mapper.Map<ExistingWorkTimeDto>(data);
                }
                else
                {
                    throw new KeyNotFoundException($"WorkTime with id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Delete the record of a particular WorkTime
        public void DeleteWorkTime (int id)
        {
            try
            {
                var data = _dbContext.WorkTimes.Find(id);
                if (data != null)
                {
                    _dbContext.WorkTimes.Remove(data);

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"WorkTime with id {id} not found.");
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

