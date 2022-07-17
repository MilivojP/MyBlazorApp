using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Shared.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlazorApp.Server.Entities
{
    [Table("Vacations")]
    public class Vacation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public DateOnly DateFrom { get; set; }

        [Required]
        public DateOnly DateTo { get; set; }

        [Required]
        public VacationStatus Status { get; set; }

        // it will be calculated
        public byte TotalDays { get; set; }

        [MaxLength(255)]
        [Unicode]
        public string? Notes { get; set; }   
    }
}
