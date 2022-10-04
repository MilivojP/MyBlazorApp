using MyBlazorApp.Server.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlazorApp.DAL.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }


        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int TotalWork { get; private set; }

        public string? Notes { get; set; }
    }
}
