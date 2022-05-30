using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Data;

namespace MyBlazorApp.Server.Services
{
    public class UserService : IUserService
    {
        readonly DatabaseContext _dbContext;

        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all user details
        public List<UserDto> GetUserDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new user record
        public void AddUser(UserDto user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar user
        public void UpdateUserDetails(UserDto user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular user
        public UserDto GetUserData(int id)
        {
            try
            {
                UserDto? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    return user;
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
        public void DeleteUser(int id)
        {
            try
            {
                UserDto? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
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
    }
}
