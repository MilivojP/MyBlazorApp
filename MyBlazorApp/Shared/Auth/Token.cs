namespace MyBlazorApp.Shared.Auth
{
    public class Token
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string message { get; set; }

        public bool Sucess { get; set; }    

    }
}
