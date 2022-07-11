using AutoMapper;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Services
{
    public class SickLeaveService : ISickLeaveService
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public SickLeaveService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public List<SickLeaveDto> GetSickLeaves()
        {
            try
            {
                var data = _dbContext.SickLeaves.OrderBy(x => x.UserId).ThenByDescending(x => x.StartDate).ToList();

                return _mapper.Map<List<SickLeaveDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        //To Get all sickleave details
        //public List<SickLeaveDto> GetSixckLeaves()
        //{
        //    try
        //    {
        //        var data = _dbContext.SickLeaves.OrderBy(x=>x.UserId).ThenByDescending(x=>x.StartDate).ToList();

        //        return _mapper.Map<List<SickLeaveDto>>(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw ex;
        //    }
        //}

        public void AddSickLeave(SickLeaveDto sick)
        {
            if (_dbContext.SickLeaves.Any(x => x.UserId == sick.UserId && x.StartDate == DateOnly.FromDateTime(sick.StartDate)))
            {
                throw new Exception("SickeLeave with this UserId and tihs StartDate already exists!");
            }

            try
            {
                var data = _mapper.Map<SickLeave>(sick);

                _dbContext.SickLeaves.Add(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void UpdateSickeLeave(SickLeaveDto sick)
        {
            try
            {
                // TODO: get sickleave from data store and then update
                var data = _dbContext.SickLeaves.Single(x => x.Id == sick.Id);
                _mapper.Map(sick, data);
                _dbContext.SickLeaves.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //Get the details of a particular sickleave
        public SickLeaveDto GetSickLeave(int id)
        {
            try
            {
                var data = _dbContext.SickLeaves.Find(id);

                if (data != null)
                {
                    return _mapper.Map<SickLeaveDto>(data);
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

        //To Delete the record of a particular sickleave
        public void DeleteSickLeave (int id)
        {
            try
            {
                var data = _dbContext.SickLeaves.Find(id);
                if (data != null)
                {
                    _dbContext.SickLeaves.Remove(data);

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

