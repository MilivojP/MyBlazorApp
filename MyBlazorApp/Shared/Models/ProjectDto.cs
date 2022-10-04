using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class ProjectDto
    {
        public int Id { get; set; } 

        public int UserId { get; set; }   
        
        public  int ProjectId { get; set; }

        public string ProjectName { get; set; }

        
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        public int TotalWork { get; set; }

        public string? Notes { get; set; }

    }

    public class NewProjectDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }


        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        public TimeSpan? TotalWork { get; private set; }

        public string? Notes { get; set; }

    }

    public class ExistingProjectDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }


        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        public TimeSpan? TotalWork { get; private set; }

        public string? Notes { get; set; }

    }
}
