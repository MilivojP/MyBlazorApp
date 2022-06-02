using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Server.Entities
{
    public class WorkTime
    {
        [Key]
        public int UserId { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public string? Notes { get; set; }
    }
}
