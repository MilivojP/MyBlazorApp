﻿using MyBlazorApp.Shared.Enumerations;
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
        
        public VacationStatus Status { get; set; }       
        public string? Notes { get; set; }
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

        public VacationStatus Status { get; set; } = VacationStatus.Requested;

        public string? Notes { get; set; }
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

        public VacationStatus Status { get; set; }

        public string? Notes { get; set; }
    }
}
