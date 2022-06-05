using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class UserDto   
    {

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare ("Password", ErrorMessage ="The Password didn't match. Type again!")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
