using AutoMapper;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Services
{
    public class VacationService : IVacationService

    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public VacationService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //To Get all vacation details
        public List<VacationDto> GetVacations()
        {
            try
            {
                var data = _dbContext.Vacations.OrderBy(x => x.UserId).ToList();
                return _mapper.Map<List<VacationDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Add new vacation record
        public void AddVacation(NewVacationDto vacation)
        {
            if (_dbContext.Vacations.Any(x => x.UserId == vacation.UserId && x.DateFrom == DateOnly.FromDateTime(vacation.DateFrom)))
            {
                throw new Exception("Vacation with this UserId and DateFrom already exists!");
            }
            // TODO: Calculate weekends
            // TODO: Calculate Holidays
            // TODO: check if another vacation exists in the same period for that user
            try
            {
                var data = _mapper.Map<Vacation>(vacation);
                _dbContext.Vacations.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Update the records vacation
        public void UpdateVacation(ExistingVacationDto Id)
        {
            try
            {
                // TODO: get worktime from data store and then update
                var data = _mapper.Map<Vacation>(Id);
                _dbContext.Vacations.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //Get the details of a particular vacation
        public ExistingVacationDto GetVacation(int id)
        {
            try
            {
                var data = _dbContext.Vacations.Find(id);

                if (data != null)
                {
                    return _mapper.Map<ExistingVacationDto>(data);
                }
                else
                {
                    throw new KeyNotFoundException($"Vacation with id {id} not found."); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Delete the record of a particular vacation
        public void DeleteVacation(int id)
        {
            try
            {
                var data = _dbContext.Vacations.Find(id);
                if (data != null)
                {
                    _dbContext.Vacations.Remove(data);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"Vacation with id {id} not found.");
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

