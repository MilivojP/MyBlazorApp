using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlazorApp.Server.Entities
{
    [Table("Vacation")]
    public class Vacation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateOnly DateFrom { get; set; }

        [Required]
        public DateOnly DateTo { get; set; }

        [Required]
        public int TotalDays { get; set; }  

        [Required]
        public bool Status { get; set; }    

        [MaxLength(255)]
        [Unicode]
        public string Descrtiption { get; set; }   

    }
}
