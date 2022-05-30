using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class UserDto   
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
