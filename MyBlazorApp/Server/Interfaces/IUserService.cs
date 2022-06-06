using MyBlazorApp.Shared.Models;
namespace MyBlazorApp.Server.Interfaces
{
    public interface IUserService
    {
        public List<UserDto> GetUsers();

        public void AddUser(NewUserDto user);

        public void UpdateUser(ExistingUserDto user);

        public ExistingUserDto GetUser(int id);

        public void DeleteUser(int id);
    }
}
