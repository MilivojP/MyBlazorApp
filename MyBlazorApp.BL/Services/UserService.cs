using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.Shared.Models;
using MyBlazorApp.DAL.Data;
using AutoMapper;
using MyBlazorApp.DAL.Entities;

namespace MyBlazorApp.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public UserService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //To Get all user details
        public List<UserDto> GetUsers()
        {
            try
            {
                var data = _dbContext.Users.OrderBy(x=>x.UserName).ToList();

                return _mapper.Map<List<UserDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Add new user record
        public void AddUser(NewUserDto user)
        {
            if (_dbContext.Users.Any(x => x.Email == user.Email))
            {
                throw new Exception("User with this email address already exists!");
            }

            try
            { 
                var data = _mapper.Map<User>(user);
                _dbContext.Users.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email is alredy exists! Please input new email!");
                throw ex;
            }   
        }

        //To Update the records of a particluar user
        public void UpdateUser(ExistingUserDto user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("Parameter 'user' is null.");
            }
            try
            {
                // (1 variant) 
                var data = _dbContext.Users.Single(x => x.Id == user.Id);
                _mapper.Map(user, data);
                _dbContext.Users.Update(data);

                // (2 variant)
                //var data2 = _mapper.Map<User>(user);
                //_dbContext.Entry(user).State = EntityState.Modified;

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

        //Get the details of a particular user
        public ExistingUserDto GetUser(int id)
        {
            try
            {
                var data = _dbContext.Users.Find(id);

                if (data != null)
                {
                    return _mapper.Map<ExistingUserDto>(data);
                }
                else
                {
                    throw new KeyNotFoundException($"User with id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Delete the record of a particular user
        public void DeleteUser(int id)
        {
            try
            {
                var data = _dbContext.Users.Find(id);
                if (data != null)
                {
                    _dbContext.Users.Remove(data);

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"User with id {id} not found.");
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
