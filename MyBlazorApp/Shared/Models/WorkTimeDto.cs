namespace MyBlazorApp.Shared.Models
{
    public class WorkTimeDto
    {
        public int UserId { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public TimeSpan? Work { get; private set; }
        public string? Notes { get; set; }
    }
}
