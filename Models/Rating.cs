using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lifestyle_Preference_survey.Models
{
    public class Rating
    {
        [Key]
        public Guid ID { get; set; }
        public Guid User_ID { get; set; }
        [Required]
        public string Movies { get; set; }
        [Required]
        public string Radio { get; set; }
        [Required]
        public string Out { get; set; }
        [Required]
        public string TV { get; set; }
    }
}