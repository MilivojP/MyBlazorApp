using MyBlazorApp.Shared.Models;
namespace MyBlazorApp.Server.Interfaces
{
    public interface IUserService
    {
        public List<UserDto> GetUserDetails();

        public void AddUser(UserDto user);

        public void UpdateUserDetails(ExistingUserDto user);

        public ExistingUserDto GetUserData(int id);

        public void DeleteUser(int id);
    }
}
