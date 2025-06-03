using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lifestyle_Preference_survey.Models
{
    public class UserDetails
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string? Fullnames { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
    }
}