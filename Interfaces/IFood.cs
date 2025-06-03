using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.Interfaces
{
    public interface IFood
    {
        List<Foods> ListAll();
        void Create(Foods food);
    }
}
