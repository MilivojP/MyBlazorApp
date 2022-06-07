using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;
using MyBlazorApp.Server.Data;
using AutoMapper;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Services
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
                var data = _dbContext.Users.ToList();
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
            try
            {
                var data = _mapper.Map<User>(user);

                _dbContext.Users.Add(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //To Update the records of a particluar user
        public void UpdateUser(ExistingUserDto user)
        {
            try
            {
                var data = _mapper.Map<User>(user);

                _dbContext.Users.Update(data);

                //_dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
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
                    throw new ArgumentNullException();
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
