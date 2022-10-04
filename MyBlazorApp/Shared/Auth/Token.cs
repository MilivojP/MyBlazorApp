namespace MyBlazorApp.Shared.Auth
{
    public class Token
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public DateTime ExpiryTimeStamp { get; set; }
    }
}
