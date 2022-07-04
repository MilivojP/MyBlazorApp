namespace MyBlazorApp.Shared.Models
{
    public class UserVacationBudgetDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public short Year { get; set; }
                
        public int TotalDays { get; set; }
    }
}
