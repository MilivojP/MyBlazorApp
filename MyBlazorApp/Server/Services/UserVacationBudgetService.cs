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
                var data = _dbContext.UserVacationsBudgets.OrderBy(x => x.UserId).ToList();

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
                var data = _dbContext.UserVacationsBudgets.Find(id);

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
        public void AddUserVacationBudget(UserVacationBudgetDto budget)
        {
            //var data = _dbContext.Vacations.Single(x => x.UserId == user.Id);
            //_mapper.Map(user, data);

            if (_dbContext.UserVacationsBudgets.Any(x => x.UserId == budget.UserId && x.Year == budget.Year))
            {
                throw new Exception("User with vacation for this year already exists!");
            }

            try
            {
                var data = _mapper.Map<UserVacationBudget>(budget);
                _dbContext.UserVacationsBudgets.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("User with vacation for this year already exists!");
                throw ex;
            }
        }

        public void UpdateUserVacationBudget(UserVacationBudgetDto Day)
        {
            // TODO: check existence of user budget (by id OR: user id + year)

            try
            {
                // (1) 
                var data = _dbContext.UserVacationsBudgets.Single(x => x.Id == Day.Id);
                _mapper.Map(Day, data);
                _dbContext.UserVacationsBudgets.Update(data);
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
                var data = _dbContext.UserVacationsBudgets.Find(id);
                if (data != null)
                {
                    _dbContext.UserVacationsBudgets.Remove(data);

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
