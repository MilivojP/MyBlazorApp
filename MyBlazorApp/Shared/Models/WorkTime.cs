using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorApp.Shared.Models
{
    public class WorkTime
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? BreakTime { get; set; }
        public DateTime? Work { get; set; }
        public string? Notes { get; set; }


    }
}
