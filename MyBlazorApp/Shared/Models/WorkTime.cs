namespace MyBlazorApp.Shared.Models
{
    public class WorkTime
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateOnly? Day { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public TimeOnly? BreakTime { get; set; }
        public TimeOnly? Work { get; set; }
        public string? Notes { get; set; }

    }
}
