using MyBlazorApp.Shared.Auth;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IAuthService
    {
        Token Login(string username, string password);
    }
}
