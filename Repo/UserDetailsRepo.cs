using Lifestyle_Preference_survey.Data;
using Lifestyle_Preference_survey.Interfaces;
using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.Repo
{
    public class UserDetailsRepo : IUserDetails
    {
        private readonly AppBDContext _context;
        public UserDetailsRepo(AppBDContext context)
        {
            _context = context;
        }
        public void Create(UserDetails userDetails)
        {
            _context.Add(userDetails);
            _context.SaveChanges();
        }

        public List<UserDetails> ListAll()
        {
            return _context.UserDetails.ToList();
        }
    }
}
