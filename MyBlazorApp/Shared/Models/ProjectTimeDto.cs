using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public abstract class ProjectTimeBaseDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Day { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int TimeSpent { get; set; }
    }
    public class ProjectTimeDto : ProjectTimeBaseDto
    {
        public int Id { get; set; }

    }
    public class NewProjectTimeDto : ProjectTimeBaseDto
    {

    }

}
