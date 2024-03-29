﻿using MyBlazorApp.Shared.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    public class SickLeaveDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public SickLeaveType LeaveType { get; set; } = SickLeaveType.SickLeaveUpTo3Days;


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; } = DateTime.Now; 

    }

}
