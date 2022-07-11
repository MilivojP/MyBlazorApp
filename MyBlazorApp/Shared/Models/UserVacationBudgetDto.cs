using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class UserVacationBudgetDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public short Year { get; set; } = 2022;

        [Required]
        public int TotalDays { get; set; } = 30;
    }
}
