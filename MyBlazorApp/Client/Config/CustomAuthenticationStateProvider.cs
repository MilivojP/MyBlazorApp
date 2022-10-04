using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyBlazorApp.Shared.Auth;
using System.Security.Claims;

namespace MyBlazorApp.Client.Config
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService; 

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _sessionStorageService.ReadEncryptedItemAsync<Token>("Token"); 
                if (token == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, token.Username),
                    new Claim(ClaimTypes.Email, token.Email),
                    new Claim(ClaimTypes.Role, token.Role),
                    new Claim(ClaimTypes.NameIdentifier, (string)token.UserId.ToString())
                }, "JwtAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous)); 
            }
        }

        public async Task UpdateAuthenticationState(Token? token)
        {
            ClaimsPrincipal claimsPrincipal;

            if (token != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, token.Username),
                    new Claim(ClaimTypes.Email, token.Email),
                    new Claim(ClaimTypes.Role, token.Role),
                    new Claim(ClaimTypes.NameIdentifier, (string)token.UserId.ToString())
                }));

                token.ExpiryTimeStamp = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
                await _sessionStorageService.SaveItemEncryptedAsync("Token", token);
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessionStorageService.RemoveItemAsync("Token");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken()
        {
            var result = string.Empty;

            try
            {
                var token = await _sessionStorageService.ReadEncryptedItemAsync<Token>("Token");
                if (token != null && DateTime.UtcNow < token.ExpiryTimeStamp)
                {
                    result = token.AccessToken;
                }
            }
            catch
            {

            }

            return result;
        }
    }
}
