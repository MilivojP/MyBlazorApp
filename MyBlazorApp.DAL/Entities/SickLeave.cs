using MyBlazorApp.Shared.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.DAL.Entities
{
    public class SickLeave
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }  

        [Required]
        public SickLeaveType LeaveType { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }
    }
}
