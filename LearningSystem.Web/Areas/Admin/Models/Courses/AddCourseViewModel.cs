using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
    public class AddCourseViewModel: IValidatableObject
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name ="Trainer")]
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date cannot be backdated");
            }

            if(this.EndDate < this.StartDate)
            {
                yield return new ValidationResult("End date should be after the start date");
            }
        }
    }
}
