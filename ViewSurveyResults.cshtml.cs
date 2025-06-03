using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lifestyle_Preference_survey
{
    public class ViewSurveyResults : PageModel
    {
        private readonly ILogger<ViewSurveyResults> _logger;

        public ViewSurveyResults(ILogger<ViewSurveyResults> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}