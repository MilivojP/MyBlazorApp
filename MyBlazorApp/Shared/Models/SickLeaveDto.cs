using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class SickLeaveDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string LeaveType { get; set; }


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

    }
}
