namespace Lifestyle_Preference_survey.Models
{
    public class SurveyResults
    {
        public int SurveyNumber { get; set; }
        public double Avarage { get; set; }
        public int Oldest { get; set; }
        public int Youngest { get; set; }


        public double PercentOfPizza { get; set; }
        public double PercentOfPasta { get; set; }
        public double PercentOfPapandWors { get; set; }

        public double TotalMovies { get; set; }
        public double Radio { get; set; }
        public double EatOut { get; set; }
        public double TV { get; set; }

    }
}