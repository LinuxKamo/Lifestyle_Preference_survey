using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.ViewModel
{
    public class UserInput
    {
        [Required(ErrorMessage = "Please enter your full name")]
        [Display(Name = "Full Name")]
        public string? Fullnames { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name =" Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter your contact number")]
        [Display(Name = "Contact Number")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "Phone number cannot be longer or lesser than 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please select your date of birth")]
        [Display(Name = "Date of Birth")]
        [Range(typeof(DateOnly), "1904-12-31", "2020-01-01", ErrorMessage = "You must be born between 2020 and 1904 to take the survey ")]
        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage ="Please select level of agreement for {0}.")]
        public string? Movies { get; set; }
        [Required(ErrorMessage = "Please select level of agreement for {0}.")]
        public string? Radio { get; set; }
        [Required(ErrorMessage = "Please select level of agreement for {0}.")]
        public string? Out { get; set; }
        [Required(ErrorMessage = "Please select level of agreement for {0}.")]
        public string? TV { get; set; }
        public string? Pizza { get; set; }
        public string? Pasta { get; set; }
        public string? PapAndWors { get; set; }
        public string? Other { get; set; }
    }
}