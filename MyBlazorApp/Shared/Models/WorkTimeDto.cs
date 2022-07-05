
using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Shared.Models
{
    /// <summary>
    /// DTO for displaying worktime in a list.
    /// </summary>
    public class WorkTimeDto
    {
        public int Id { get; set; }
                
        public int UserId { get; set; }

       
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Day { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
      
        public TimeSpan BreakTime { get; set; }
        
        public DateTime? Work { get; private set; }

        public TimeSpan TotalWork { get; private set; }

        public string? Notes { get; set; }
    }

    /// <summary>
    /// DTO for adding a new worktime.
    /// </summary>
    public class NewWorkTimeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Day { get; set; } = DateTime.UtcNow.Date;

        [Required(ErrorMessage = "The Start Time field is Required")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; } = new DateTime(1, 1, 1, 8, 0, 0, 0);

        [Required(ErrorMessage = "The End Time field is Required")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        //[DateGreaterThanAttribute(otherPropertyName = "StartTime", ErrorMessage = "End time must be greater than start time")]
        public DateTime EndTime { get; set; }= new DateTime(1, 1, 1, 16, 0, 0, 0);
        public TimeSpan BreakTime { get; set; } = TimeSpan.FromMinutes(30.0);
        public TimeSpan? Work { get; private set; }
        public TimeSpan? TotalWork { get;private set; }
        public string? Notes { get; set; }
    }

    /// <summary>
    /// DTO for changing existing worktime, or displaying worktime details.
    /// </summary>
    public class ExistingWorkTimeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Day { get; set; } 

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
     
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh/mm}", ApplyFormatInEditMode = true)]
        //[DateGreaterThanAttribute(otherPropertyName = "StartTime", ErrorMessage = "End time must be greater than start time")]
        public DateTime EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public TimeSpan? Work { get; private set; }
        public TimeSpan? TotalWork { get; private set; }
        public string? Notes { get; set; }
    }
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public string otherPropertyName;
        public DateGreaterThanAttribute() { }
        public DateGreaterThanAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                // Using reflection we can get a reference to the other date/time property, in this example the project start date/time
                var containerType = validationContext.ObjectInstance.GetType();
                var field = containerType.GetProperty(this.otherPropertyName);
                var extensionValue = field.GetValue(validationContext.ObjectInstance, null);
                var datatype = extensionValue.GetType();

                //var otherPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(this.otherPropertyName);
                if (field == null)
                    return new ValidationResult(String.Format("Unknown property: {0}.", otherPropertyName));
                // Let's check that otherProperty is of type DateTime as we expect it to be
                if ((field.PropertyType == typeof(DateTime) || (field.PropertyType.IsGenericType && field.PropertyType == typeof(Nullable<DateTime>))))
                {
                    DateTime toValidate = (DateTime)value;
                    DateTime referenceProperty = (DateTime)field.GetValue(validationContext.ObjectInstance, null);
                    // if the end date is lower than the start date, than the validationResult will be set to false and return
                    // a properly formatted error message
                    if (toValidate.CompareTo(referenceProperty) < 1)
                    {
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property. OtherProperty is not of type DateTime");
                }
            }
            catch (Exception ex)
            {
                // Do stuff, i.e. log the exception
                // Let it go through the upper levels, something bad happened
                throw ex;
            }

            return validationResult;
        }
    }
}
