namespace MyBlazorApp.Shared.Models
{
    /// <summary>
    /// DTO for displaying worktime in a list.
    /// </summary>
    public class WorkTimeDto
    {
        public int UserId { get; set; }
        public DateTime Day { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public DateTime? Work { get; private set; }
        public string? Notes { get; set; }
    }

    /// <summary>
    /// DTO for adding a new worktime.
    /// </summary>
    public class NewWorkTimeDto
    {
        public int UserId { get; set; }
        public DateTime Day { get; set; } = DateTime.Now;
        public DateTime StartTime { get; set; } 

        public DateTime EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public TimeSpan? Work { get; private set; }
        public string? Notes { get; set; }
    }

    /// <summary>
    /// DTO for changing existing worktime, or displaying worktime details.
    /// </summary>
    public class ExistingWorkTimeDto
    {
        public int UserId { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public TimeSpan? Work { get; private set; }
        public string? Notes { get; set; }
    }

}
