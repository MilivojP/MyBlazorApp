using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Data;
using AutoMapper;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Services
{
    public class WorkTimeServices : IWorkTimeServices
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContextWork;

        public WorkTimeServices(IMapper mapper, DatabaseContext dbContextWork)
        {
            _mapper = mapper;
            _dbContextWork = dbContextWork;
        }

        //To Get all user details
        public List<WorkTimeDto> GetWorkTimeDetails()
        {
            try
            {
                var data = _dbContextWork.WorkTimes.ToList();

                return _mapper.Map<List<WorkTimeDto>>(data);
            }
            catch
            {
                throw;
            }
        }

        //To Add new user record
        public void AddWorkTime(WorkTimeDto workTime)
        {
            try
            {
                var data = _mapper.Map<WorkTime>(workTime);

                _dbContextWork.WorkTimes.Add(data);

                _dbContextWork.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar user
        public void UpdateWorkTimeDetails(WorkTime UserId)
        {
            try
            {
                // TODO: get worktime from data store and then update

                _dbContextWork.Entry(UserId).State = EntityState.Modified;
                _dbContextWork.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular user
        public WorkTimeDto GetWorkTimeData(int id)
        {
            try
            {
                var data = _dbContextWork.WorkTimes.Find(id);

                if (data != null)
                {
                    return _mapper.Map<WorkTimeDto>(data);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular user
        public void DeleteWorkTime(int id)
        {
            try
            {
                var data = _dbContextWork.WorkTimes.Find(id);
                if (data != null)
                {
                    _dbContextWork.WorkTimes.Remove(data);

                    _dbContextWork.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        WorkTimeDto IWorkTimeServices.GetWorkTimeData(int UserId)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkTimeDetails(WorkTimeDto UserId)
        {
            throw new NotImplementedException();
        }
    }
}

