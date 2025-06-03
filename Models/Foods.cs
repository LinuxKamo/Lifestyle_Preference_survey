using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lifestyle_Preference_survey.Models
{
    public class Foods
    {
        [Key]
        public Guid ID { get; set; }
        public Guid User_ID { get; set; }
        public string Pizza { get; set; }
        public string Pasta { get; set; }
        public string PapAndWors { get; set; }
        public string Other { get; set; }
    }
}