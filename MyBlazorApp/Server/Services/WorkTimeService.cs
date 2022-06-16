using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Data;
using AutoMapper;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Services
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
                throw ex;
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
                    throw new ArgumentNullException();
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

