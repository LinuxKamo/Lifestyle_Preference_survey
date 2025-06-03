using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.Interfaces
{
    public interface IRating
    {
        List<Rating> ListAll();
        void Create(Rating rating);
    }
}
