using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlazorApp.Server.Entities
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode(false)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Unicode(false)]
        public string Email { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
