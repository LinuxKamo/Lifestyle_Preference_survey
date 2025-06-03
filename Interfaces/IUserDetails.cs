using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.Interfaces
{
    public interface IUserDetails
    {
        List<UserDetails> ListAll();
        void Create(UserDetails userDetails);
    }
}
