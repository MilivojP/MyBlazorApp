using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    /// <summary>
    /// DTO for displaying vacation a list.
    /// </summary>
    public class VacationDto
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        
        public int TotalDays { get; set; }
        
        public bool Status { get; set; }
        
        public string Descrtiption { get; set; }
    }

    /// <summary>
    /// DTO for adding a new vacation 
    /// </summary>
    public class NewVacationDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DateFrom { get; set; } = DateTime.UtcNow.Date;

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; } = DateTime.UtcNow.Date;

        public int TotalDays { get; set; }=30;   

        public bool Status { get; set; }

        public string Descrtiption { get; set; }
    }

    /// <summary>
    /// DTO for changing exisitng vacation 
    /// </summary>
    public class ExistingVacationDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        public int TotalDays { get; set; }

        public bool Status { get; set; }

        public string Descrtiption { get; set; }
    }
}
