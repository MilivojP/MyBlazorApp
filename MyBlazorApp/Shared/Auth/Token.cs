namespace MyBlazorApp.Shared.Auth
{
    public class Token
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public DateTime ExpiryTimeStamp { get; set; }
    }
}
