using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Server.Entities
{
    public class Holiday
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        public DateOnly HolidayDate{ get; set; }
        
        [Required]
        [MaxLength(50)]
        public string HolidayName{ get; set; }  
    }
}
