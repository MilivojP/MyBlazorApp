using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlazorApp.Server.Entities
{
    [Table("WorkTime")]
    public class WorkTime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateOnly Day { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public TimeSpan BreakTime { get; set; }

        [MaxLength(255)]
        [Unicode]
        public string? Notes { get; set; }
    }
}
