using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    /// <summary>
    /// DTO for displaying user in a list.
    /// </summary>
    public class UserDto   
    {
        public int Id { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare ("Password", ErrorMessage ="The Password didn't match. Type again!")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    /// <summary>
    /// DTO for adding a new user.
    /// </summary>
    public class NewUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The Password didn't match. Type again!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }

    /// <summary>
    /// DTO for changing existing user, or displaying user details.
    /// </summary>
    public class ExistingUserDto 
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
