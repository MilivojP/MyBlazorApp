using MyBlazorApp.Shared.Auth;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IAuthService
    {
        Token Login(string username, string password);
    }
}
