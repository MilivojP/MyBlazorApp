using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class HolidayDto
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HolidayDate { get; set; } = new DateTime(year: 2022, 01, 01);   


        [Required]
        public string HolidayName { get; set; }
    }
}
