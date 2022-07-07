using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Server.Entities
{
    public class SickLeave
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }  

        [Required]
        [MaxLength(50)]
        public string LeaveType { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate{ get; set; }


    }
}
