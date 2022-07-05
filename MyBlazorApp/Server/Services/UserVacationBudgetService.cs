using AutoMapper;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Services
{
    public class UserVacationBudgetService : IUserVacationBudgetService

    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public UserVacationBudgetService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public List<UserVacationBudgetDto> GetUserVacationsBudget()
        {
            try
            {
                var data = _dbContext.UserVacationsBudget.OrderBy(x => x.UserId).ToList();

                return _mapper.Map<List<UserVacationBudgetDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public UserVacationBudgetDto GetUserVacationBudgetDto(int id)
        {
            try
            {
                var data = _dbContext.UserVacationsBudget.Find(id);

                if (data != null)
                {
                    return _mapper.Map<UserVacationBudgetDto>(data);
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
        public void AddUserVacationBudget(UserVacationBudgetDto user)
        {
            //var data = _dbContext.Vacations.Single(x => x.UserId == user.Id);
            //_mapper.Map(user, data);

            if (_dbContext.UserVacationsBudget.Any(x => x.Year== user.Year))
            {
                throw new Exception("User with vacation for this year already exists!");
            }

            try
            {
                var data = _mapper.Map<UserVacationBudget>(user);
                _dbContext.UserVacationsBudget.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("User with vacation for this year already exists!");
                throw ex;
            }
        }

        public void UpdateUserVacationBudget(UserVacationBudgetDto user)
        {
            try
            {
                // (1) 
                var data = _dbContext.UserVacationsBudget.Single(x => x.Id == user.Id);
                _mapper.Map(user, data);
                _dbContext.UserVacationsBudget.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void DeleteUserVacationBudgetDto(int id)
        {
            try
            {
                var data = _dbContext.UserVacationsBudget.Find(id);
                if (data != null)
                {
                    _dbContext.UserVacationsBudget.Remove(data);

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
